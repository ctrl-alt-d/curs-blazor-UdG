using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using Blogging.Server;
using System.Threading.Tasks;
using System.Net;
using BusinessLayer.Abstractionns;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Blogging.Shared;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using FluentAssertions;
using FluentAssertions.Common;
using System.Net.Http.Json;

namespace Server.Test
{

    public class MyWebApplicationFactory : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            // will be called after the `ConfigureServices` from the Startup
            builder.ConfigureTestServices(services =>
            {
                services.AddTransient<IBlogBusinessLayer, BlogBusinessFakeLayer>();
            });
        }
    }

    public class BlogWebApiTest : IClassFixture<MyWebApplicationFactory>
    {

        private readonly MyWebApplicationFactory Fixture;

        public BlogWebApiTest(MyWebApplicationFactory fixture)
        {
            Fixture = fixture;
        }

        [Fact]
        public async Task GetAllTest()
        {
            // arrange
            var client = Fixture.CreateClient();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            // act
            var response = await client.GetAsync("/api/Blog/GetAll");

            // assert: result code
            var expected_status_code = HttpStatusCode.OK;
            Assert.Equal(expected_status_code, response.StatusCode);

            // asert: content
            var content = await response.Content.ReadAsStringAsync();
            var methodresult = JsonSerializer.Deserialize<MethodResult<List<BlogDto>>>(content, options);
            var methodresult_expected = await new BlogBusinessFakeLayer().GetAll();
            methodresult.Should().IsSameOrEqualTo(methodresult_expected);
        }

        [Fact]
        public async Task CreateTest()
        {
            // arrange
            var client = Fixture.CreateClient();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            var parms = new BlogCreateParms
            {
                NomBlog = "xxx",
                TitolPrimerPost = "yyy"
            };

            // act
            var response = await client.PostAsJsonAsync("/api/Blog/Create", parms);

            // assert: result code
            var expected_status_code = HttpStatusCode.OK;
            Assert.Equal(expected_status_code, response.StatusCode);

            // asert: content
            var content = await response.Content.ReadAsStringAsync();
            var methodresult = JsonSerializer.Deserialize<MethodResult<BlogDto>>(content, options);
            var methodresult_expected = await new BlogBusinessFakeLayer().Create(parms);
            methodresult.Should().IsSameOrEqualTo(methodresult_expected);
        }


    }
}

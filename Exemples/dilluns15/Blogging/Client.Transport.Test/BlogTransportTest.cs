using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using Blogging.Server;
using System.Threading.Tasks;
using BusinessLayer.Abstractionns;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Blogging.Shared;
using Microsoft.Extensions.DependencyInjection;
using FluentAssertions;
using FluentAssertions.Common;

namespace Client.Transport.Test
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

    public class BlogTransportTest : IClassFixture<MyWebApplicationFactory>
    {

        private readonly MyWebApplicationFactory Fixture;

        public BlogTransportTest(MyWebApplicationFactory fixture)
        {
            Fixture = fixture;
        }

        [Fact]
        public async Task GetAllTest()
        {
            // arrange
            var blogTransport = new BlogTransport(Fixture.CreateClient());

            // act
            var response = await blogTransport.GetAll();

            // asert: content
            var methodresult_expected = await new BlogBusinessFakeLayer().GetAll();
            response.Should().IsSameOrEqualTo(methodresult_expected);
        }

        [Fact]
        public async Task CreateTest()
        {
            // arrange
            var blogTransport = new BlogTransport(Fixture.CreateClient());
            var parms = new BlogCreateParms
            {
                NomBlog = "xxx",
                TitolPrimerPost = "yyy"
            };

            // act
            var response = await blogTransport.Create(parms);

            // asert: content
            var methodresult_expected = await new BlogBusinessFakeLayer().Create(parms);
            response.Should().IsSameOrEqualTo(methodresult_expected);
        }

    }
}

using Blogging.Shared;
using BusinessLayer.Abstractionns;
using Datalayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer
{

    public class BlogBusinessLayer : IBlogBusinessLayer
    {
        private readonly IDbContextFactory<MyContext> MyFactory;

        public BlogBusinessLayer(IDbContextFactory<MyContext> myFactory)
        {
            MyFactory = myFactory;
        }

        public async Task<MethodResult<BlogDto>> Create(BlogCreateParms parms)
        {
            using var ctx = MyFactory.CreateDbContext();

            // pre-condicions

            // body
            var blog = new Blog
            {
                Nom = parms.NomBlog
            };
            var post = new Post
            {
                Blog = blog,
                Content = "Contingut del meu primer blog",
                Title = parms.TitolPrimerPost
            };

            // persistim
            ctx.Add(post);
            ctx.Add(blog);
            await ctx.SaveChangesAsync();

            // retornem
            MethodResult<BlogDto> result = new MethodResult<BlogDto>
            {
                Data = new BlogDto
                {
                    Id = blog.BlogId,
                    DataDePublicacio = blog.DiaDePublicacio,
                    Nom = blog.Nom,
                    TitolsDelsPosts = blog.Posts.Select(p => p.Title).ToList()
                }
            };
            return result;
        }

        public async Task<MethodResult<BlogDto>> GetById(int id)
        {
            using var ctx = MyFactory.CreateDbContext();

            // pre-condicions

            // body
            var blog = await ctx.Blogs.FindAsync(id);

            //
            if (blog == null)
            {
                return new MethodResult<BlogDto>
                {
                    Errors = new List<string> { "No trobat " }
                };
            }

            // retornem
            var result = CalculaMethodResult(blog);
            return result;
        }

        private static MethodResult<BlogDto> CalculaMethodResult(Blog blog)
        {
            return new MethodResult<BlogDto>
            {
                Data = new BlogDto
                {
                    Id = blog.BlogId,
                    DataDePublicacio = blog.DiaDePublicacio,
                    Nom = blog.Nom,
                    TitolsDelsPosts = blog.Posts.Select(p => p.Title).ToList()
                }
            };
        }

        public async Task<MethodResult<List<BlogDto>>> GetAll()
        {
            var ctx = MyFactory.CreateDbContext();

            // pre-condicions

            // body
            var blogs_db =
                await ctx
                .Blogs
                .Include(b => b.Posts)
                .ToListAsync()
                ;

            var blogs_dto =
                blogs_db
                .Select(blog =>
                     new BlogDto
                     {
                         Id = blog.BlogId,
                         DataDePublicacio = blog.DiaDePublicacio,
                         Nom = blog.Nom,
                         TitolsDelsPosts = blog.Posts.Select(p => p.Title).ToList()
                     }
                 )
                .ToList();

            // retornem
            var result = new MethodResult<List<BlogDto>>
            {
                Data = blogs_dto
            };
            return result;
        }

        public async Task<MethodResult<BlogDto>> PublicaBlog(int id)
        {
            using var ctx = MyFactory.CreateDbContext();

            // pre-condicions

            // body
            var blog = await ctx.Blogs.FindAsync(id);

            //
            if (blog == null)
            {
                return new MethodResult<BlogDto>
                {
                    Errors = new List<string> { "No trobat " }
                };
            }

            blog.DiaDePublicacio = DateTime.Now;

            // persistim
            await ctx.SaveChangesAsync();

            // retornem
            var result = CalculaMethodResult(blog);
            return result;
        }


        public async Task<MethodResult<BlogDto>> CanviaNom(BlogCanviaNomParams parms)
        {
            using var ctx = MyFactory.CreateDbContext();

            // pre-condicions

            // body
            var blog = await ctx.Blogs.FindAsync(parms.Id);

            //
            if (blog == null)
            {
                return new MethodResult<BlogDto>
                {
                    Errors = new List<string> { "No trobat " }
                };
            }

            //
            if (blog.DiaDePublicacio.HasValue)
            {
                return new MethodResult<BlogDto>
                {
                    Errors = new List<string> { "No li podem canviar el nom a un blog publicat" }
                };
            }


            //
            blog.Nom = parms.NouNom;

            // persistim
            await ctx.SaveChangesAsync();

            // retornem
            var result = CalculaMethodResult(blog);
            return result;
        }

    }
}

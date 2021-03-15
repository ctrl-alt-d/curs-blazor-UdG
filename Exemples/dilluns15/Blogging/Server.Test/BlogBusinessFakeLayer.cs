using System;
using System.Threading.Tasks;
using BusinessLayer.Abstractionns;
using Blogging.Shared;
using System.Collections.Generic;

namespace Server.Test
{
    public class BlogBusinessFakeLayer : IBlogBusinessLayer
    {
        public Task<MethodResult<BlogDto>> CanviaNom(BlogCanviaNomParams parms)
        {
            var result = new MethodResult<BlogDto>
            {
                Data = new BlogDto
                {
                    Id = parms.Id,
                    Nom = parms.NouNom,
                    TitolsDelsPosts = new()
                    {
                        "fake titol"
                    }
                }
            };
            return Task.FromResult(result);
        }

        public Task<MethodResult<BlogDto>> Create(BlogCreateParms parms)
        {
            var result = new MethodResult<BlogDto>
            {
                Data = new BlogDto
                {
                    Id = 100,
                    Nom = parms.NomBlog,
                    TitolsDelsPosts = new()
                    {
                        parms.TitolPrimerPost
                    }
                }
            };
            return Task.FromResult(result);
        }

        public Task<MethodResult<List<BlogDto>>> GetAll()
        {
            var result = new MethodResult<List<BlogDto>>
            {
                Data = new List<BlogDto>
                {
                    new BlogDto
                    {
                        Id = 1,
                        Nom= "Fake blog",
                        TitolsDelsPosts = new()
                        {
                            "fake titol"
                        }
                    }
                }
            };
            return Task.FromResult(result);
        }

        public Task<MethodResult<BlogDto>> GetById(int id)
        {
            var result = new MethodResult<BlogDto>
            {
                Data = new BlogDto
                {
                    Id = id,
                    Nom = "fake nom",
                    TitolsDelsPosts = new()
                    {
                        "fake titol"
                    }
                }
            };
            return Task.FromResult(result);
        }

        public Task<MethodResult<BlogDto>> PublicaBlog(int id)
        {
            var result = new MethodResult<BlogDto>
            {
                Data = new BlogDto
                {
                    Id = id,
                    Nom = "fake nom",
                    DataDePublicacio = DateTime.Now,
                    TitolsDelsPosts = new()
                    {
                        "fake titol"
                    }

                }
            };
            return Task.FromResult(result);
        }
    }
}

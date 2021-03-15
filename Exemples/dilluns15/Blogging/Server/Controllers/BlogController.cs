using Blogging.Shared;
using BusinessLayer.Abstractionns;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogging.Server.Controllers
{

    [ApiController]
    [Route("/api/[controller]")]
    public class BlogController : ControllerBase, IBlogBusinessLayer
    {
        private readonly IBlogBusinessLayer _BlogBusinessLayer;

        public BlogController(IBlogBusinessLayer blogBusinessLayer)
        {
            _BlogBusinessLayer = blogBusinessLayer;
        }

        [HttpPost("[action]")]
        public Task<MethodResult<BlogDto>> CanviaNom([FromBody] BlogCanviaNomParams parms)
        {
            return _BlogBusinessLayer.CanviaNom(parms);
        }

        [HttpPost("[action]")]
        public Task<MethodResult<BlogDto>> Create([FromBody]  BlogCreateParms parms)
        {
            return _BlogBusinessLayer.Create(parms);
        }

        [HttpGet("[action]")]
        public Task<MethodResult<List<BlogDto>>> GetAll()
        {
            return _BlogBusinessLayer.GetAll();
        }

        [HttpGet("[action]/{id:int}")]
        public Task<MethodResult<BlogDto>> GetById(int id)
        {
            return _BlogBusinessLayer.GetById(id);
        }

        [HttpPost("[action]")]
        public Task<MethodResult<BlogDto>> PublicaBlog([FromBody] int id)
        {
            return _BlogBusinessLayer.PublicaBlog(id);
        }
    }
}

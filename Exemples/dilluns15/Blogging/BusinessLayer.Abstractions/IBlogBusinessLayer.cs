using Blogging.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Abstractionns
{
    public interface IBlogBusinessLayer
    {
        Task<MethodResult<BlogDto>> CanviaNom(BlogCanviaNomParams parms);
        Task<MethodResult<BlogDto>> Create(BlogCreateParms parms);
        Task<MethodResult<List<BlogDto>>> GetAll();
        Task<MethodResult<BlogDto>> GetById(int id);
        Task<MethodResult<BlogDto>> PublicaBlog(int id);
    }
}
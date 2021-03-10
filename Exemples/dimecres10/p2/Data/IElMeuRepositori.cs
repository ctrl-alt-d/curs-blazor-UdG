using System.Collections.Generic;
using System.Threading.Tasks;

namespace p2.Data
{
    public interface IElMeuRepositori
    {
        Task<List<string>> GetDades();
    }
}
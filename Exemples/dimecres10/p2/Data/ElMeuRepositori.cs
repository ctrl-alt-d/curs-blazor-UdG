using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace p2.Data
{
    public class ElMeuRepositori : IElMeuRepositori
    {
        private List<string> _LesMevesDades { get; set; } = new List<string>()
        {
            "Pepita",
            "Manolita",
            "Juanito",
            "Toni"
        };

        public async Task<List<string>> GetDades()
        {
            await Task.Delay(2000);
            return _LesMevesDades;
        }
    }
}

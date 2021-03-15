using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogging.Shared
{
    public record BlogCanviaNomParams
    {
        public int Id { get; set; }
        public string NouNom { get; set; } = string.Empty;
    }
}

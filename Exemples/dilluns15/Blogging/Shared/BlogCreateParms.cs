using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogging.Shared
{
    public record BlogCreateParms
    {
        public string NomBlog { get; set; } = string.Empty;
        public string TitolPrimerPost { get; set; } = string.Empty;
    }
}

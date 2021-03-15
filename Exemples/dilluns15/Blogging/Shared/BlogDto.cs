using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogging.Shared
{
    public record BlogDto
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public DateTime? DataDePublicacio { get; set; }
        public List<string> TitolsDelsPosts { get; set; } = new();
    }
}

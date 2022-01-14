using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortLink.Models
{
    public class Links
    {
        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataModificacao { get; set; }
        public string LinkOriginal { get; set; }
        public string LinkEncurtado { get; set; }
        public bool Contador { get; set; }
    }
}

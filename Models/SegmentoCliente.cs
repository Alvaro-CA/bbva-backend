using System;
using System.Collections.Generic;

namespace bbva_backend.Models
{
    public partial class SegmentoCliente
    {
        public int? IdSegmento { get; set; }
        public int? IdCliente { get; set; }

        public virtual Cliente? IdClienteNavigation { get; set; }
        public virtual Segmento? IdSegmentoNavigation { get; set; }
    }
}

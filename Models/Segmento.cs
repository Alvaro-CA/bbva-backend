using System;
using System.Collections.Generic;

namespace bbva_backend.Models
{
    public partial class Segmento
    {
        public int IdSegmento { get; set; }
        public string? NombreSegmento { get; set; }
        public int? Jerarquia { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace bbva_backend.Models
{
    public partial class Cliente
    {
        public int IdCliente { get; set; }
        public string Contrasena { get; set; } = null!;
        public string? Nombre { get; set; }
        public string? NumeroDocumento { get; set; }
        public bool? FlgEsCliente { get; set; }
        public string? Direccion { get; set; }
        public int? IdSegmento { get; set; }
    }
}

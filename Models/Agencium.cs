using System;
using System.Collections.Generic;

namespace bbva_backend.Models
{
    public partial class Agencium
    {
        public int IdAgencia { get; set; }
        public string? NombreAgencia { get; set; }
        public string? Direccion { get; set; }
        public string? Distrito { get; set; }
        public string? Provincia { get; set; }
        public decimal? Aforo { get; set; }
        public decimal? CapacidadActual { get; set; }
        public decimal? Altitud { get; set; }
        public decimal? Latitud { get; set; }
        public int IdRegion { get; set; }
        public int IdUbigeo { get; set; }
    }
}

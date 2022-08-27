using System;
using System.Collections.Generic;

namespace bbva_backend.Models
{
    public partial class Ubigeo
    {
        public int IdUbigeo { get; set; }
        public string? IdDepartamento { get; set; }
        public string? IdProvincia { get; set; }
        public string? IdDistrito { get; set; }
        public string? CodigoUbigeo { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace bbva_backend.Models
{
    public partial class Region
    {
        public Region()
        {
            Agencia = new HashSet<Agencium>();
        }

        public int IdRegion { get; set; }
        public string? NombreRegion { get; set; }

        public virtual ICollection<Agencium> Agencia { get; set; }
    }
}

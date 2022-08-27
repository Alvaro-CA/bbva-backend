using System;
using System.Collections.Generic;

namespace bbva_backend.Models
{
    public partial class Agencium
    {
        public Agencium()
        {
            Tickets = new HashSet<Ticket>();
        }

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
        public string HorarioInicioAtencion { get; set; } = null!;
        public string HorarioCierreAtencion { get; set; } = null!;
        public int IdSegmento { get; set; }

        public virtual Region IdRegionNavigation { get; set; } = null!;
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}

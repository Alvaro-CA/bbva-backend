using System;
using System.Collections.Generic;

namespace bbva_backend.Models
{
    public partial class Ticket
    {
        public int IdTicket { get; set; }
        public string? Estado { get; set; }
        public int? IdAgencia { get; set; }
        public int? IdCliente { get; set; }
        public string? FechaHoraIngreso { get; set; }
        public string? FechaHoraSalida { get; set; }
        public string? AtendidoPor { get; set; }

        public virtual Agencium? IdAgenciaNavigation { get; set; }
        public virtual Cliente? IdClienteNavigation { get; set; }
    }
}

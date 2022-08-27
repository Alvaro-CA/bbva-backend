using System;
using System.Collections.Generic;

namespace bbva_backend.Models
{
    public partial class Ticket
    {
        public int IdTicket { get; set; }
        public string? Estado { get; set; }
        public int IdAgencia { get; set; }
        public int IdCliente { get; set; }
        public DateTime? FechaHoraIngreso { get; set; }
        public DateTime? FechaHoraSalida { get; set; }
        public DateTime? FechaHoraCreacion { get; set; }
        public DateTime? FechaHoraActualizacion { get; set; }
        public int AtendidoPor { get; set; }
    }
}

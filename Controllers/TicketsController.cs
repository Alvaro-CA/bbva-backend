using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bbva_backend.Models;

namespace bbva_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {

        starWebDbContext db = new starWebDbContext();


        [HttpPost]
        [Route("CrearTicket")]
        public IActionResult CrearTicket(string dni, int idAgencia)
        {
            int idCliente = db.Clientes.Where(x => x.NumeroDocumento == dni).Select(x => x.IdCliente).FirstOrDefault();

            db.Tickets.Add(new Ticket
            {
                IdTicket = 0,
                Estado = "C",
                IdAgencia = idAgencia,
                IdCliente = idCliente == 0 ? null : idCliente,
                FechaHoraIngreso = DateTime.Now.ToString(),
                AtendidoPor = ""

            });
            db.SaveChanges();

            string mensaje = "";

            return Ok(mensaje);
        }

        [HttpPost]
        [Route("AtenderTicket")]
        public IActionResult AtenderTicket(int idTicket)
        {

            var objTicket = db.Tickets.Where(x => x.IdTicket == idTicket).FirstOrDefault();
            if (objTicket != null)
            {
                objTicket.Estado = "A";
                db.SaveChanges();
            }
            string mensaje = "";

            return Ok(mensaje);
        }

        [HttpPost]
        [Route("TerminarTicket")]
        public IActionResult TerminarTicket(int idTicket)
        {
            var objTicket = db.Tickets.Where(x => x.IdTicket == idTicket).FirstOrDefault();
            if (objTicket != null)
            {
                objTicket.Estado = "T";
                objTicket.FechaHoraSalida = DateTime.Now.ToString();
                db.SaveChanges();
            var agencia = db.Agencia.Where(x => x.IdAgencia == objTicket.IdAgencia).FirstOrDefault();
            if (agencia != null)
            { 
                if(agencia.CapacidadActual > 0 ){
                  agencia.CapacidadActual = agencia.CapacidadActual-1;
                 db.SaveChanges();
                }
           
            }
            }
            string mensaje = "";
            return Ok(mensaje);
        }

        [HttpGet]
        [Route("ObtenerTicketsAtendiendose")]
        public IActionResult ObtenerTicketsAtendiendose(int idAgencia)
        {
            string fechaHoy = DateTime.Now.ToString("dd/MM/yyyy");
            var objTickets = db.Tickets.Where(x => x.IdAgencia == idAgencia && x.Estado=="A"&& x.FechaHoraIngreso.Substring(0,10)==fechaHoy ).Select(x=>x.IdTicket).ToList() ;


            return Ok(objTickets);
        }

        [HttpGet]
        [Route("ObtenerTicketsCreadosSinAtender")]
        public IActionResult ObtenerTicketsCreadosSinAtender(int idAgencia)
        {
            string fechaHoy = DateTime.Now.ToString("dd/MM/yyyy");
            var objTickets = db.Tickets.Where(x => x.IdAgencia == idAgencia && x.Estado == "C" && x.FechaHoraIngreso.Substring(0, 10) == fechaHoy).Select(x=>x.IdTicket).ToList();
            return Ok(objTickets);
        }

        [HttpGet]
        [Route("ListarTicketsHoy")]
        public IActionResult ListarTicketsHoy()
        {
            string fechaHoy = DateTime.Now.ToString("dd/MM/yyyy");
            var objTickets = db.Tickets.Where(x =>  x.FechaHoraIngreso.Substring(0, 10) == fechaHoy).ToList();


            return Ok(objTickets);
        }

        [HttpGet]
        [Route("ListarTickets")]
        public IActionResult ListarTickets()
        {
            var objTickets = db.Tickets.ToList();

            return Ok(objTickets);
        }


    }


}

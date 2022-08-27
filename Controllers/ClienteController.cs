using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bbva_backend.Models;
using Microsoft.AspNetCore.Mvc;


namespace bbva_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {


        [HttpPost]
        public IActionResult logeoClient(string dni, string password)
        {

            starWebDbContext db = new starWebDbContext();
            Cliente cliente = db.Clientes.Where(x => (x.NumeroDocumento == dni) && (x.Contrasena == password))
            .FirstOrDefault();
            if (cliente != null)
            {
                Segmento segmento = db.Segmentos.Where(x => x.IdSegmento == cliente.IdSegmento).FirstOrDefault();
                if (segmento != null)
                {
                    return Ok(new LogeoClienteResponse()
                    {
                        nombreClient = cliente.Nombre,
                        idSegmento = segmento.IdSegmento,
                        nombreSegmento = segmento.NombreSegmento
                    });
                }

            }
            return Ok("Error de credencial");

        }


    }
}
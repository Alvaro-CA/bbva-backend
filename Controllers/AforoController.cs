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
    public class AforoController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(AforoData aforoData)
        {

            starWebDbContext dbContext = new starWebDbContext();
            Agencium agencia = dbContext.Agencia.Where((agencia) => agencia.IdAgencia == aforoData.idAgencia).FirstOrDefault();

            if (agencia != null)
            {
                agencia.CapacidadActual = aforoData.aforo;
                dbContext.SaveChanges();
                return Ok("Actualizado Correctamente");
            }
            return BadRequest("No Se encuentra el ID");
            
        }
    }
}
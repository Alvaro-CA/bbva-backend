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
                updateAleatoryData();
                return Ok("Actualizado Correctamente");
            }
            
            return BadRequest("No Se encuentra el ID");

        }

        void updateAleatoryData()
        {
            starWebDbContext dbContext = new starWebDbContext();

            foreach (var agencia in dbContext.Agencia.Where((agencia) => agencia.IdAgencia < 142 || agencia.IdAgencia > 146))
            {
                Random rd = new Random();
                agencia.CapacidadActual = rd.Next(0, Convert.ToInt32(agencia.Aforo));
            }
            dbContext.SaveChanges();
        }
    }
}
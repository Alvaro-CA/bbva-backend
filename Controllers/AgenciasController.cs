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
    public class AgenciasController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            starWebDbContext dbContext = new starWebDbContext();


            var a = dbContext.Agencia.Select((agencia) => new AgenciaData(
                agencia.NombreAgencia,
                agencia.Direccion,
                agencia.Aforo,
                agencia.CapacidadActual,
                agencia.Altitud,
                agencia.Latitud,
                agencia.HorarioCierreAtencion));

            return Ok(a);


        }
    }
}
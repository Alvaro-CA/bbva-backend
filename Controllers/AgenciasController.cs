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

            using (var db = new starWebDbContext())
            {
                var agencias = db.Agencia;
                if (agencias != null)
                {
                    return Ok(dbContext.Agencia.Select((agencia) => new
                    {
                        agencia.NombreAgencia,
                        agencia.Direccion,
                        agencia.Aforo,
                        agencia.CapacidadActual,
                        agencia.Altitud,
                        agencia.Latitud,
                        color = (agencia.CapacidadActual / agencia.Aforo) * 100 <= 30 ? "v" : (agencia.CapacidadActual / agencia.Aforo) * 100 <= 60 ? "a" : "r",
                        horarioAtencion = agencia.HorarioInicioAtencion + " - " + agencia.HorarioCierreAtencion,
                        agencia.IdUbigeo
                    }));
                }
                return BadRequest();
            }



        }

        string calcularColor(decimal? capacidadActual, decimal? aforo)
        {
            decimal result = 0;
            if (capacidadActual != null && aforo != null)
            {
                result = (decimal)((capacidadActual + aforo) * 100);
            }
            // if ()
            return result.ToString();
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetAllId()
        {
            starWebDbContext dbContext = new starWebDbContext();

            return Ok(dbContext.Agencia.Select((agencia) => new
            {
                agencia.IdAgencia
            }));
        }
    }
}
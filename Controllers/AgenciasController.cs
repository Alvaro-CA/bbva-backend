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

            return Ok(dbContext.Agencia.Select((agencia) => new
            {
                agencia.NombreAgencia,
                agencia.Direccion,
                agencia.Aforo,
                agencia.CapacidadActual,
                agencia.Altitud,
                agencia.Latitud,
                horarioAtencion = agencia.HorarioInicioAtencion + " - " + agencia.HorarioCierreAtencion
            }));
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
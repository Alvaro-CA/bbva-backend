using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bbva_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CamarasAgenciasController : ControllerBase
    {
        [HttpGet]
        [Route("GetImagenAgencia")]
        public IActionResult GetImagenAgencia(int idAgencia)
        {
            byte[] imageArray = System.IO.File.ReadAllBytes(@"./Imagenes/"+ idAgencia+".jpg");
            string base64ImageRepresentation = Convert.ToBase64String(imageArray);

            return Ok(base64ImageRepresentation);
        }

        


    }
}

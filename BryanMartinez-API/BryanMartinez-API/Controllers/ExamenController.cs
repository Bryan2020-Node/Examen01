using Logica.interfaz;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BryanMartinez_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamenController : ControllerBase
    {
        ISucursal _sucursal;

        public ExamenController(ISucursal sucursal)
        {
            _sucursal = sucursal;
        }

        [HttpGet]
        [Route("ObtenerRegistros/{id}/{fecha}")]
        public IActionResult GetDatos(string id, DateTime fecha) 
        {
            var result = _sucursal.consultaRegistros(id, fecha);
            return StatusCode(StatusCodes.Status200OK, new
            {
                ok = true
            });
        }
    }
}

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

        [HttpPost]
        [Route("NuevoRegistros/{id}/{fecha}")]
        public IActionResult NuevoDato(string id, DateTime fecha) 
        {
            var result = _sucursal.NuevoDato(id, fecha);
            return StatusCode(StatusCodes.Status200OK, new
            {
                ok = true
            });
        }


        [HttpGet]
        [Route("ObtenerRegistrosId/{ids}")]
        public IActionResult GetDatosIds(string ids)
        {
            var result = _sucursal.ObtenerDatos(ids);
            if (result.Count() != 0)
            {
                return StatusCode(StatusCodes.Status200OK, new
                {
                    ok = true,
                    results = result
                });
            }
            else
            {
                return StatusCode(StatusCodes.Status404NotFound, new
                {
                    ok = false,
                    items = result.Count(),
                    results = new
                    {
                        message = "Sin resultados"
                    }
                });
            }
        }
    }
}

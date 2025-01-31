using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace RestauranteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatoPrincipalController : ControllerBase
    {
        private static List<PlatoPrincipal> platos = new List<PlatoPrincipal>();

        [HttpGet]
        public ActionResult<IEnumerable<PlatoPrincipal>> GetPlatos()
        {
            return Ok(platos);
        }

        [HttpGet("{id}")]
        public ActionResult<PlatoPrincipal> GetPlato(int id)
        {
            var plato = platos.FirstOrDefault(p => p.Id == id);
            if (plato == null)
            {
                return NotFound();
            }
            return Ok(plato);
        }

        [HttpPost]
        public ActionResult<PlatoPrincipal> CreatePlato(PlatoPrincipal plato)
        {
            platos.Add(plato);
            return CreatedAtAction(nameof(GetPlato), new { id = plato.Id }, plato);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePlato(int id, PlatoPrincipal updatedPlato)
        {
            var plato = platos.FirstOrDefault(p => p.Id == id);
            if (plato == null)
            {
                return NotFound();
            }
            plato.Nombre = updatedPlato.Nombre;
            plato.Precio = updatedPlato.Precio;
            plato.Ingredientes = updatedPlato.Ingredientes;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePlato(int id)
        {
            var plato = platos.FirstOrDefault(p => p.Id == id);
            if (plato == null)
            {
                return NotFound();
            }
            platos.Remove(plato);
            return NoContent();
        }

        // Método para inicializar datos
        public static void InicializarDatos()
        {
            platos.Add(new PlatoPrincipal("Plato combinado", 12.50, "Pollo, patatas, tomate"));
            platos.Add(new PlatoPrincipal("Plato vegetariano", 10.00, "Tofu, verduras, arroz"));
        }

    }
}
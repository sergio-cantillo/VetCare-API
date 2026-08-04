using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VetCare.Api.Data;
using VetCare.Api.DTOs;
using VetCare.Api.Models;

namespace VetCare.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VeterinariosController : ControllerBase
    {
        private readonly VetCareDbContext _context;

        public VeterinariosController(VetCareDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VeterinarioRespuestaDto>>> ObtenerTodos()
        {
            var veterinarios = await _context.Veterinarios
                .Select(v => new VeterinarioRespuestaDto
                {
                    Id = v.Id,
                    Nombre = v.Nombre,
                    Especialidad = v.Especialidad
                })
                .ToListAsync();

            return Ok(veterinarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VeterinarioRespuestaDto>> ObtenerPorId(int id)
        {
            var veterinario = await _context.Veterinarios.FindAsync(id);

            if (veterinario == null)
                return NotFound(new
                {
                    mensaje = "Veterinario no encontrado."
                });

            return Ok(new VeterinarioRespuestaDto
            {
                Id = veterinario.Id,
                Nombre = veterinario.Nombre,
                Especialidad = veterinario.Especialidad
            });
        }

        [HttpPost]
        public async Task<ActionResult> Crear(VeterinarioCrearDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var veterinario = new Veterinario
            {
                Nombre = dto.Nombre,
                Especialidad = dto.Especialidad
            };

            _context.Veterinarios.Add(veterinario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(ObtenerPorId),
                new { id = veterinario.Id },
                new
                {
                    mensaje = "Veterinario registrado correctamente.",
                    datos = new
                    {
                        veterinario.Id,
                        veterinario.Nombre,
                        veterinario.Especialidad
                    }
                });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, VeterinarioCrearDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
                
            var veterinario = await _context.Veterinarios.FindAsync(id);

            if (veterinario == null)
                return NotFound(new
                {
                    mensaje = "Veterinario no encontrado."
                });

            veterinario.Nombre = dto.Nombre;
            veterinario.Especialidad = dto.Especialidad;

            await _context.SaveChangesAsync();

            return Ok(new
            {
                mensaje = "Veterinario actualizado correctamente."
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var veterinario = await _context.Veterinarios.FindAsync(id);

            if (veterinario == null)
                return NotFound(new
                {
                    mensaje = "Veterinario no encontrado."
                });

            _context.Veterinarios.Remove(veterinario);

            await _context.SaveChangesAsync();

            return Ok(new
            {
                mensaje = "Veterinario eliminado correctamente."
            });
        }
    }
}
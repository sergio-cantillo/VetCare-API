using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VetCare.Api.Data;
using VetCare.Api.DTOs;
using VetCare.Api.Models;

namespace VetCare.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropietariosController : ControllerBase
    {
        private readonly VetCareDbContext _context;

        public PropietariosController(VetCareDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PropietarioRespuestaDto>>> ObtenerTodos()
        {
            var propietarios = await _context.Propietarios
                .Select(p => new PropietarioRespuestaDto
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    Apellido = p.Apellido,
                    Telefono = p.Telefono,
                    Correo = p.Correo
                })
                .ToListAsync();

            return Ok(propietarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PropietarioRespuestaDto>> ObtenerPorId(int id)
        {
            var propietario = await _context.Propietarios.FindAsync(id);

            if (propietario == null)
                return NotFound(new
                {
                    mensaje = "Propietario no encontrado."
                });

            return Ok(new PropietarioRespuestaDto
            {
                Id = propietario.Id,
                Nombre = propietario.Nombre,
                Apellido = propietario.Apellido,
                Telefono = propietario.Telefono,
                Correo = propietario.Correo
            });
        }

        [HttpPost]
        public async Task<ActionResult> Crear(PropietarioCrearDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var propietario = new Propietario
            {
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Telefono = dto.Telefono,
                Correo = dto.Correo
            };

            _context.Propietarios.Add(propietario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(ObtenerPorId),
                new { id = propietario.Id },
                new
                {
                    mensaje = "Propietario registrado correctamente.",
                    datos = new
                    {
                        propietario.Id,
                        propietario.Nombre,
                        propietario.Apellido,
                        propietario.Telefono,
                        propietario.Correo
                    }
                });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, PropietarioCrearDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var propietario = await _context.Propietarios.FindAsync(id);

            if (propietario == null)
                return NotFound(new
                {
                    mensaje = "Propietario no encontrado."
                });

            propietario.Nombre = dto.Nombre;
            propietario.Apellido = dto.Apellido;
            propietario.Telefono = dto.Telefono;
            propietario.Correo = dto.Correo;

            await _context.SaveChangesAsync();

            return Ok(new
            {
                mensaje = "Propietario actualizado correctamente."
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var propietario = await _context.Propietarios.FindAsync(id);

            if (propietario == null)
                return NotFound(new
                {
                    mensaje = "Propietario no encontrado."
                });

            _context.Propietarios.Remove(propietario);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                mensaje = "Propietario eliminado correctamente."
            });
        }
    }
}
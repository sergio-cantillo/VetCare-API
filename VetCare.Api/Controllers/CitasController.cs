using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VetCare.Api.Data;
using VetCare.Api.DTOs;
using VetCare.Api.Models;

namespace VetCare.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitasController : ControllerBase
    {
        private readonly VetCareDbContext _context;

        public CitasController(VetCareDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CitaRespuestaDto>>> ObtenerTodas()
        {
            var citas = await _context.Citas
                .Include(c => c.Mascota)
                .Include(c => c.Veterinario)
                .Select(c => new CitaRespuestaDto
                {
                    Id = c.Id,
                    Fecha = c.Fecha,
                    Motivo = c.Motivo,

                    MascotaId = c.MascotaId,
                    Mascota = c.Mascota!.Nombre,

                    VeterinarioId = c.VeterinarioId,
                    Veterinario = c.Veterinario!.Nombre
                })
                .ToListAsync();

            return Ok(citas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CitaRespuestaDto>> ObtenerPorId(int id)
        {
            var cita = await _context.Citas
                .Include(c => c.Mascota)
                .Include(c => c.Veterinario)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cita == null)
                return NotFound(new
                {
                    mensaje = "Cita no encontrada."
                });

            return Ok(new CitaRespuestaDto
            {
                Id = cita.Id,
                Fecha = cita.Fecha,
                Motivo = cita.Motivo,

                MascotaId = cita.MascotaId,
                Mascota = cita.Mascota!.Nombre,

                VeterinarioId = cita.VeterinarioId,
                Veterinario = cita.Veterinario!.Nombre
            });
        }

        [HttpPost]
        public async Task<ActionResult> Crear(CitaCrearDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var mascotaExiste = await _context.Mascotas
                .AnyAsync(m => m.Id == dto.MascotaId);

            if (!mascotaExiste)
            {
                return BadRequest(new
                {
                    mensaje = "La mascota no existe."
                });
            }

            var veterinarioExiste = await _context.Veterinarios
                .AnyAsync(v => v.Id == dto.VeterinarioId);

            if (!veterinarioExiste)
            {
                return BadRequest(new
                {
                    mensaje = "El veterinario no existe."
                });
            }
            var cita = new Cita
            {
                Fecha = dto.Fecha,
                Motivo = dto.Motivo,
                MascotaId = dto.MascotaId,
                VeterinarioId = dto.VeterinarioId
            };

            _context.Citas.Add(cita);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(ObtenerPorId),
                new { id = cita.Id },
                new
                {
                    mensaje = "Cita registrada correctamente.",
                    datos = new
                    {
                        cita.Id,
                        cita.Fecha,
                        cita.Motivo,
                        cita.MascotaId,
                        cita.VeterinarioId
                    }
                });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, CitaCrearDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var cita = await _context.Citas.FindAsync(id);

            if (cita == null)
            {
                return NotFound(new
                {
                    mensaje = "Cita no encontrada."
                });
            }

            var mascotaExiste = await _context.Mascotas
                .AnyAsync(m => m.Id == dto.MascotaId);

            if (!mascotaExiste)
            {
                return BadRequest(new
                {
                    mensaje = "La mascota no existe."
                });
            }

            var veterinarioExiste = await _context.Veterinarios
                .AnyAsync(v => v.Id == dto.VeterinarioId);

            if (!veterinarioExiste)
            {
                return BadRequest(new
                {
                    mensaje = "El veterinario no existe."
                });
            }

            cita.Fecha = dto.Fecha;
            cita.Motivo = dto.Motivo;
            cita.MascotaId = dto.MascotaId;
            cita.VeterinarioId = dto.VeterinarioId;

            await _context.SaveChangesAsync();

            return Ok(new
            {
                mensaje = "Cita actualizada correctamente."
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var cita = await _context.Citas.FindAsync(id);

            if (cita == null)
                return NotFound(new
                {
                    mensaje = "Cita no encontrada."
                });

            _context.Citas.Remove(cita);

            await _context.SaveChangesAsync();

            return Ok(new
            {
                mensaje = "Cita eliminada correctamente."
            });
        }
    }
}
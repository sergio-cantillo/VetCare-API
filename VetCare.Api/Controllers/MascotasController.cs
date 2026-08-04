using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VetCare.Api.Data;
using VetCare.Api.DTOs;
using VetCare.Api.Models;
using VetCare.Api.AI;

namespace VetCare.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MascotasController : ControllerBase
    {
        private readonly VetCareDbContext _context;
        private readonly GroqService _groqService;

        public MascotasController(
            VetCareDbContext context,
            GroqService groqService)
        {
            _context = context;
            _groqService = groqService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<MascotaRespuestaDto>>> ObtenerTodas()
        {
            var mascotas = await _context.Mascotas
                .Select(m => new MascotaRespuestaDto
                {
                    Id = m.Id,
                    Nombre = m.Nombre,
                    Especie = m.Especie,
                    Raza = m.Raza ?? "",
                    Edad = m.Edad,
                    Peso = m.Peso,
                    Sintomas = m.Sintomas ?? ""
                })
                .ToListAsync();

            return Ok(mascotas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MascotaRespuestaDto>> ObtenerPorId(int id)
        {
            var mascota = await _context.Mascotas.FindAsync(id);

            if (mascota == null)
            {
                return NotFound(new
                {
                    mensaje = "No se encontró la mascota."
                });
            }

            return Ok(new MascotaRespuestaDto
            {
                Id = mascota.Id,
                Nombre = mascota.Nombre,
                Especie = mascota.Especie,
                Raza = mascota.Raza ?? "",
                Edad = mascota.Edad,
                Peso = mascota.Peso,
                Sintomas = mascota.Sintomas ?? ""
            });
        }

        [HttpPost]
        public async Task<ActionResult> Crear(MascotaCrearDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var propietarioExiste = await _context.Propietarios
                .AnyAsync(p => p.Id == dto.PropietarioId);

            if (!propietarioExiste)
            {
                return BadRequest(new
                {
                    mensaje = "El propietario no existe."
                });
            }    
            var mascota = new Mascota
            {
                Nombre = dto.Nombre,
                Especie = dto.Especie,
                Raza = dto.Raza,
                Edad = dto.Edad,
                Peso = dto.Peso,
                Sintomas = dto.Sintomas,
                PropietarioId = dto.PropietarioId
            };

            _context.Mascotas.Add(mascota);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(ObtenerPorId),
                new { id = mascota.Id },
                new
                {
                    mensaje = "Mascota registrada correctamente.",
                    datos = new
                    {
                        mascota.Id,
                        mascota.Nombre,
                        mascota.Especie,
                        mascota.Raza,
                        mascota.Edad,
                        mascota.Peso,
                        mascota.Sintomas,
                        mascota.PropietarioId
                    }
                });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, MascotaActualizarDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var propietarioExiste = await _context.Propietarios
                .AnyAsync(p => p.Id == dto.PropietarioId);

            if (!propietarioExiste)
            {
                return BadRequest(new
                {
                    mensaje = "El propietario no existe."
                });
            }
            var mascota = await _context.Mascotas.FindAsync(id);

            if (mascota == null)
            {
                return NotFound(new
                {
                    mensaje = "No se encontró la mascota."
                });
            }

            mascota.Nombre = dto.Nombre;
            mascota.Especie = dto.Especie;
            mascota.Raza = dto.Raza;
            mascota.Edad = dto.Edad;
            mascota.Peso = dto.Peso;
            mascota.Sintomas = dto.Sintomas;
            mascota.PropietarioId = dto.PropietarioId;

            await _context.SaveChangesAsync();

            return Ok(new
            {
                mensaje = "Mascota actualizada correctamente."
            });
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var mascota = await _context.Mascotas.FindAsync(id);

            if (mascota == null)
            {
                return NotFound(new
                {
                    mensaje = "No se encontró la mascota."
                });
            }

            _context.Mascotas.Remove(mascota);

            await _context.SaveChangesAsync();

            return Ok(new
            {
                mensaje = "Mascota eliminada correctamente."
            });
        }

        [HttpPost("{id}/analizar")]
        public async Task<ActionResult> AnalizarMascota(int id)
        {
            var respuesta = await _groqService.AnalizarMascota(id);

            return Ok(new
            {
                mascotaId = id,
                recomendacion = respuesta
            });
        }
    }
}
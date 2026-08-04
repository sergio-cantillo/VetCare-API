using System.ComponentModel.DataAnnotations;

namespace VetCare.Api.DTOs
{
    public class CitaCrearDto
    {
        [Required(ErrorMessage = "La fecha es obligatoria.")]
        public DateTime Fecha { get; set; }

        [MaxLength(300)]
        public string? Motivo { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una mascota.")]
        public int MascotaId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un veterinario.")]
        public int VeterinarioId { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace VetCare.Api.DTOs
{
    public class MascotaCrearDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La especie es obligatoria.")]
        [MaxLength(50)]
        public string Especie { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? Raza { get; set; }

        [Range(0, 30, ErrorMessage = "La edad debe estar entre 0 y 30 años.")]
        public int Edad { get; set; }

        [Range(0.1, 200, ErrorMessage = "El peso debe ser mayor que cero.")]
        public double Peso { get; set; }

        [MaxLength(300)]
        public string? Sintomas { get; set; }

        [Range(1, int.MaxValue)]
        public int PropietarioId { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace VetCare.Api.Models
{
    public class Mascota
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Especie { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? Raza { get; set; }

        [Range(0, 30)]
        public int Edad { get; set; }

        [Range(0.1, 200)]
        public double Peso { get; set; }

        [MaxLength(500)]
        public string? Sintomas { get; set; }

        public int PropietarioId { get; set; }

        public Propietario? Propietario { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace VetCare.Api.Models
{
    public class Propietario
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Apellido { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string Telefono { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? Correo { get; set; }

        public ICollection<Mascota>? Mascotas { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace VetCare.Api.DTOs
{
    public class VeterinarioCrearDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La especialidad es obligatoria.")]
        [MaxLength(100)]
        public string Especialidad { get; set; } = string.Empty;
    }
}
using System.ComponentModel.DataAnnotations;

namespace VetCare.Api.Models
{
    public class Cita
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        [MaxLength(300)]
        public string? Motivo { get; set; }

        public int MascotaId { get; set; }

        public Mascota? Mascota { get; set; }

        public int VeterinarioId { get; set; }

        public Veterinario? Veterinario { get; set; }
    }
}
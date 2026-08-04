namespace VetCare.Api.DTOs
{
    public class CitaRespuestaDto
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public string? Motivo { get; set; }

        public int MascotaId { get; set; }

        public string Mascota { get; set; } = string.Empty;

        public int VeterinarioId { get; set; }

        public string Veterinario { get; set; } = string.Empty;
    }
}
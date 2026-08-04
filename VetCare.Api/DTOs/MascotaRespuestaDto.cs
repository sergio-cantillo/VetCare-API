namespace VetCare.Api.DTOs
{
    public class MascotaRespuestaDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Especie { get; set; } = string.Empty;

        public string Raza { get; set; } = string.Empty;

        public int Edad { get; set; }

        public double Peso { get; set; }

        public string Sintomas { get; set; } = string.Empty;
    }
}
using System.Text;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using VetCare.Api.Data;

namespace VetCare.Api.AI
{
    public class GroqService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly VetCareDbContext _context;

        public GroqService(
            HttpClient httpClient,
            IConfiguration configuration,
            VetCareDbContext context)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _context = context;
        }

        public async Task<string> AnalizarMascota(int mascotaId)
        {
            var mascota = await _context.Mascotas
                .Include(m => m.Propietario)
                .FirstOrDefaultAsync(m => m.Id == mascotaId);

            if (mascota == null)
                return "Mascota no encontrada.";

            var apiKey = _configuration["Groq:ApiKey"];

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            var prompt = $"""
Eres un veterinario.

Analiza esta mascota:

Nombre: {mascota.Nombre}
Especie: {mascota.Especie}
Raza: {mascota.Raza}
Edad: {mascota.Edad}
Peso: {mascota.Peso}
Síntomas: {mascota.Sintomas}

Genera recomendaciones generales.
Aclara que no sustituyen una consulta veterinaria.
""";

            var body = new
            {
                model = "llama-3.3-70b-versatile",
                messages = new[]
                {
                    new
                    {
                        role = "user",
                        content = prompt
                    }
                }
            };

            var json = JsonConvert.SerializeObject(body);

            var response = await _httpClient.PostAsync(
                "https://api.groq.com/openai/v1/chat/completions",
                new StringContent(json, Encoding.UTF8, "application/json"));

            var resultado = await response.Content.ReadAsStringAsync();

            dynamic data = JsonConvert.DeserializeObject(resultado)!;

            return data.choices[0].message.content.ToString();
        }
    }
}
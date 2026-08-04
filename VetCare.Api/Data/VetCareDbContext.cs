using Microsoft.EntityFrameworkCore;
using VetCare.Api.Models;

namespace VetCare.Api.Data
{
    public class VetCareDbContext : DbContext
    {
        public VetCareDbContext(DbContextOptions<VetCareDbContext> options)
            : base(options)
        {
        }

        public DbSet<Mascota> Mascotas { get; set; }

        public DbSet<Propietario> Propietarios { get; set; }

        public DbSet<Veterinario> Veterinarios { get; set; }

        public DbSet<Cita> Citas { get; set; }
    }
}
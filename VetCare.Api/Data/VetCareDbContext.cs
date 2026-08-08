using Microsoft.EntityFrameworkCore;
using VetCare.Api.Models;

namespace VetCare.Api.Data
{
    public class VetCareDbContext : DbContext
    {
        public VetCareDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Mascota> Mascotas { get; set; }

        public DbSet<Propietario> Propietarios { get; set; }

        public DbSet<Veterinario> Veterinarios { get; set; }

        public DbSet<Cita> Citas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Propietario>()
                .Property(p => p.Id)
                .UseIdentityByDefaultColumn();

            modelBuilder.Entity<Mascota>()
                .Property(m => m.Id)
                .UseIdentityByDefaultColumn();

            modelBuilder.Entity<Veterinario>()
                .Property(v => v.Id)
                .UseIdentityByDefaultColumn();

            modelBuilder.Entity<Cita>()
                .Property(c => c.Id)
                .UseIdentityByDefaultColumn();
        }
    }
}
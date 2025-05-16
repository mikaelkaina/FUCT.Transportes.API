using Microsoft.EntityFrameworkCore;
using FUCT.Transportes.API.Models;

namespace FUCT.Transportes.API.Data
{
    public class TransportesContext : DbContext
    {
        public TransportesContext(DbContextOptions<TransportesContext> options) : base(options) { }

        public DbSet<Cargueiro> Cargueiros { get; set; }
        public DbSet<Transporte> Transportes { get; set; }
        public DbSet<Minério> Minerios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cargueiro>().HasData(
                new Cargueiro { Id = 1, Classe = "I", Capacidade = 5, TipoMinérioCompatível = "D" },
                new Cargueiro { Id = 2, Classe = "II", Capacidade = 3, TipoMinérioCompatível = "A" },
                new Cargueiro { Id = 3, Classe = "III", Capacidade = 2, TipoMinérioCompatível = "C" },
                new Cargueiro { Id = 4, Classe = "IV", Capacidade = 0.5, TipoMinérioCompatível = "B,C" }
            );

            modelBuilder.Entity<Minério>().HasData(
                new Minério { Id = 1, Nome = "A", Caracteristica = "Inflamável 🔥", PrecoPorKg = 5000 },
                new Minério { Id = 2, Nome = "B", Caracteristica = "Risco Biológico ☣", PrecoPorKg = 10000 },
                new Minério { Id = 3, Nome = "C", Caracteristica = "Refrigerado 🧊", PrecoPorKg = 3000 },
                new Minério { Id = 4, Nome = "D", Caracteristica = "Sem características especiais", PrecoPorKg = 100 }
            );
        }

    }
}

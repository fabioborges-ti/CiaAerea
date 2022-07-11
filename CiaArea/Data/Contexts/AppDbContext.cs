using CiaArea.Entities;
using Microsoft.EntityFrameworkCore;

namespace CiaArea.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Aeronave> Aeronaves => Set<Aeronave>();
        public DbSet<Piloto> Pilotos => Set<Piloto>();
        public DbSet<Voo> Voos => Set<Voo>();
        public DbSet<Cancelamento> Cancelamentos => Set<Cancelamento>();
        public DbSet<Manutencao> Manutencoes => Set<Manutencao>();
    }
}

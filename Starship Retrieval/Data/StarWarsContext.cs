using Microsoft.EntityFrameworkCore;
using StarshipRetrieval.Models;

namespace StarshipRetrieval.Data
{
    public class StarWarsContext : DbContext
    {
        public StarWarsContext(DbContextOptions<StarWarsContext> options) : base(options)
        {
        }

        public DbSet<StarShip> StarShips { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<People> People { get; set; }
        public DbSet<Planet> Planets { get; set; }
        public DbSet<Species> Species { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StarShip>().ToTable("StarShip");
            modelBuilder.Entity<Film>().ToTable("Film");
            modelBuilder.Entity<People>().ToTable("Person");
            modelBuilder.Entity<Planet>().ToTable("Planet");
            modelBuilder.Entity<Species>().ToTable("Species");
            modelBuilder.Entity<Vehicle>().ToTable("Vehicle");
        }
    }
}

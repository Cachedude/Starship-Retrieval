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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<StarShip>().HasMany(e => e.Films).WithMany(e => e.StarShips);
            builder.Entity<StarShip>().HasMany(e => e.Pilots).WithMany(e => e.StarShips);
            builder.Entity<StarShip>().Ignore(e => e.filmsStrings);
            builder.Entity<StarShip>().Ignore(e => e.pilotsStrings);

            builder.Entity<Film>().HasMany(e => e.Species).WithMany(e => e.Films);
            builder.Entity<Film>().HasMany(e => e.Vehicles).WithMany(e => e.Films);
            builder.Entity<Film>().HasMany(e => e.Characters).WithMany(e => e.Films);
            builder.Entity<Film>().HasMany(e => e.Planets).WithMany(e => e.Films);
            builder.Entity<Film>().Ignore(e => e.speciesStrings);
            builder.Entity<Film>().Ignore(e => e.starShipsStrings);
            builder.Entity<Film>().Ignore(e => e.vehiclesStrings);
            builder.Entity<Film>().Ignore(e => e.charactersStrings);
            builder.Entity<Film>().Ignore(e => e.planetsStrings);

            builder.Entity<People>().HasMany(e => e.Species).WithMany(e => e.People);
            builder.Entity<People>().HasMany(e => e.Vehicles).WithMany(e => e.Pilots);
            builder.Entity<People>().HasOne(e => e.HomeWorld).WithMany(e => e.Residents);
            builder.Entity<People>().Ignore(e => e.homeworldString);
            builder.Entity<People>().Ignore(e => e.filmsStrings);
            builder.Entity<People>().Ignore(e => e.speciesStrings);
            builder.Entity<People>().Ignore(e => e.vehiclesStrings);
            builder.Entity<People>().Ignore(e => e.starShipsStrings);

            builder.Entity<Planet>().Ignore(e => e.residentsStrings);
            builder.Entity<Planet>().Ignore(e => e.filmsStrings);

            builder.Entity<Species>().Ignore(e => e.homeworldString);
            builder.Entity<Species>().Ignore(e => e.filmsStrings);
            builder.Entity<Species>().Ignore(e => e.peopleStrings);

            builder.Entity<Vehicle>().Ignore(e => e.pilotsStrings);
            builder.Entity<Vehicle>().Ignore(e => e.filmsStrings);


            builder.Entity<StarShip>().ToTable("StarShip");
            builder.Entity<Film>().ToTable("Film");
            builder.Entity<People>().ToTable("Person");
            builder.Entity<Planet>().ToTable("Planet");
            builder.Entity<Species>().ToTable("Species");
            builder.Entity<Vehicle>().ToTable("Vehicle");
        }
    }
}

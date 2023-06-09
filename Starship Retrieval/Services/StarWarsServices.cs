using Microsoft.EntityFrameworkCore;
using StarshipRetrieval.Data;
using StarshipRetrieval.Models;

namespace StarshipRetrieval.Services
{
    public class StarWarsServices : IStarWarsServices
    {
        private readonly StarWarsContext database;

        public StarWarsServices(StarWarsContext database) 
        {
            this.database = database;
        }

        #region Add Methods
        public async Task AddFilmAsync(Film film)
        {
            try
            {
                database.Films.Add(film);
                await database.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error adding a Film. ex:" + ex.ToString());
            }
        }

        public async Task AddPersonAsync(People person)
        {
            try
            {
                database.People.Add(person);
                await database.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding a person. ex:" + ex.ToString());
            }
        }

        public async Task AddPlanetAsync(Planet planet)
        {
            try
            {
                database.Planets.Add(planet);
                await database.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding a Planet. ex:" + ex.ToString());
            }
        }

        public async Task AddSpeciesAsync(Species species)
        {
            try
            {
                database.Species.Add(species);
                await database.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding a Species. ex:" + ex.ToString());
            }
        }

        public async Task AddStarShipAsync(StarShip ship)
        {
            try
            {
                database.StarShips.Add(ship);
                await database.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding a StarShip. ex:" + ex.ToString());
            }
        }

        public async Task AddVehicleAsync(Vehicle vehicle)
        {
            try
            {
                database.Vehicles.Add(vehicle);
                await database.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding a Vehicle. ex:" + ex.ToString());
            }
        }
        #endregion

        #region Get Methods
        public async Task<List<StarShip>> GetStarShipsAsync(bool includePilots = false, bool includeFilms = false)
        {
            try
            {
                var query = database.StarShips.AsQueryable();
                if (includePilots)
                {
                    query = query.Include(f => f.Pilots).ThenInclude(f => f.HomeWorld);
                }
                if (includeFilms)
                {
                    query = query.Include(f => f.Films);
                }

                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error returning all StarShips. ex:" + ex.ToString());
                return null;
            }
        }

        public async Task<StarShip> GetStarShipsAsync(int shipID, bool includePilots = false, bool includeFilms = false)
        {
            try
            {
                var query = database.StarShips.AsQueryable();
                if (includePilots)
                {
                    query = query.Include(f => f.Pilots);
                }
                if (includeFilms)
                {
                    query = query.Include(f => f.Films);
                }

                return await query.FirstOrDefaultAsync(e => e.ShipID == shipID);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error return StarShip with ID: {shipID}. ex: {ex.ToString()}");
                return null;
            }
        }

        public async Task<List<Film>> GetFilmsAsync(bool includeSpecies = false, bool includeStarShips = false, bool includeCharacters = false, bool includeVehicles = false, bool includePlanets = false)
        {
            try
            {
                var query = database.Films.AsQueryable();
                if (includeSpecies)
                {
                    query = query.Include(f => f.Species);
                }
                if (includeStarShips)
                {
                    query = query.Include(f => f.StarShips);
                }
                if (includeCharacters)
                {
                    query = query.Include(f => f.Characters);
                }
                if (includeVehicles)
                {
                    query = query.Include(f => f.Vehicles);
                }
                if (includePlanets)
                {
                    query = query.Include(f => f.Planets);
                }

                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error returning all Films. ex:" + ex.ToString());
                return null;
            }
        }

        public async Task<Film> GetFilmsAsync(int filmID, bool includeSpecies = false, bool includeStarShips = false, bool includeCharacters = false, bool includeVehicles = false, bool includePlanets = false)
        {
            try
            {
                var query = database.Films.AsQueryable();
                if (includeSpecies)
                {
                    query = query.Include(f => f.Species);
                }
                if (includeStarShips)
                {
                    query = query.Include(f => f.StarShips);
                }
                if (includeCharacters)
                {
                    query = query.Include(f => f.Characters);
                }
                if (includeVehicles)
                {
                    query = query.Include(f => f.Vehicles);
                }
                if (includePlanets)
                {
                    query = query.Include(f => f.Planets);
                }

                return await query.FirstOrDefaultAsync(e => e.FilmID == filmID);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error return Film with ID: {filmID}. ex: {ex.ToString()}");
                return null;
            }
        }

        public async Task<List<People>> GetPeopleAsync(bool includeSpecies = false, bool includeFilms = false, bool includeStarShips = false, bool includeVehicles = false)
        {
            try
            {
                var query = database.People.Include(f => f.HomeWorld).AsQueryable();
                if (includeSpecies)
                {
                    query = query.Include(f => f.Species);
                }
                if (includeFilms)
                {
                    query = query.Include(f => f.Films);
                }
                if (includeStarShips)
                {
                    query = query.Include(f => f.StarShips);
                }
                if (includeVehicles)
                {
                    query = query.Include(f => f.Vehicles);
                }

                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error returning all People. ex:" + ex.ToString());
                return null;
            }
        }

        public async Task<People> GetPeopleAsync(int personID, bool includeSpecies = false, bool includeFilms = false, bool includeStarShips = false, bool includeVehicles = false)
        {
            try
            {
                var query = database.People.AsQueryable();
                if (includeSpecies)
                {
                    query = query.Include(f => f.Species);
                }
                if (includeFilms)
                {
                    query = query.Include(f => f.Films);
                }
                if (includeStarShips)
                {
                    query = query.Include(f => f.StarShips);
                }
                if (includeVehicles)
                {
                    query = query.Include(f => f.Vehicles);
                }

                return await query.FirstOrDefaultAsync(e => e.PeopleID == personID);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error return Person with ID: {personID}. ex: {ex.ToString()}");
                return null;
            }
        }

        public async Task<List<Planet>> GetPlanetsAsync(bool includeResidents = false, bool includeFilms = false)
        {
            try
            {
                var query = database.Planets.AsQueryable();
                if (includeResidents)
                {
                    query = query.Include(f => f.Residents);
                }
                if (includeFilms)
                {
                    query = query.Include(f => f.Films);
                }

                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error returning all Planets. ex:" + ex.ToString());
                return null;
            }
        }

        public async Task<Planet> GetPlanetsAsync(int planetID, bool includeResidents = false, bool includeFilms = false)
        {
            try
            {
                var query = database.Planets.AsQueryable();
                if (includeResidents)
                {
                    query = query.Include(f => f.Residents);
                }
                if (includeFilms)
                {
                    query = query.Include(f => f.Films);
                }

                return await query.FirstOrDefaultAsync(e => e.PlanetID == planetID);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error return Planet with ID: {planetID}. ex: {ex.ToString()}");
                return null;
            }
        }

        public async Task<List<Species>> GetSpeciesAsync(bool includePeople = false, bool includeFilms = false)
        {
            try
            {
                var query = database.Species.AsQueryable();
                if (includePeople)
                {
                    query = query.Include(f => f.People);
                }
                if (includeFilms)
                {
                    query = query.Include(f => f.Films);
                }
                
                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error returning all Species. ex:" + ex.ToString());
                return null;
            }
        }

        public async Task<Species> GetSpeciesAsync(int speciesID, bool includePeople = false, bool includeFilms = false)
        {
            try
            {
                var query = database.Species.AsQueryable();
                if (includePeople)
                {
                    query = query.Include(f => f.People);
                }
                if (includeFilms)
                {
                    query = query.Include(f => f.Films);
                }

                return await query.FirstOrDefaultAsync(e => e.SpeciesID == speciesID);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error return Species with ID: {speciesID}. ex: {ex.ToString()}");
                return null;
            }
        }

        public async Task<List<Vehicle>> GetVehiclesAsync(bool includePilots = false, bool includeFilms = false)
        {
            try
            {
                var query = database.Vehicles.AsQueryable();
                if (includePilots)
                {
                    query = query.Include(f => f.Pilots);
                }
                if (includeFilms)
                {
                    query = query.Include(f => f.Films);
                }

                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error returning all Vehicles. ex:" + ex.ToString());
                return null;
            }
        }

        public async Task<Vehicle> GetVehiclesAsync(int vehicleID, bool includePilots = false, bool includeFilms = false)
        {
            try
            {
                var query = database.Vehicles.AsQueryable();
                if (includePilots)
                {
                    query = query.Include(f => f.Pilots);
                }
                if (includeFilms)
                {
                    query = query.Include(f => f.Films);
                }

                return await query.FirstOrDefaultAsync(e => e.VehicleID == vehicleID);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error return Vehicle with ID: {vehicleID}. ex: {ex.ToString()}");
                return null;
            }
        }
        #endregion

        #region Update Methods
        public async Task UpdateFilmAsync(Film film)
        {
            try
            {
                database.Films.Update(film);
                await database.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating Film with ID: {film.FilmID}. ex: {ex.ToString()}");
            }
        }

        public async Task UpdatePersonAsync(People person)
        {
            try
            {
                database.People.Update(person);
                await database.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating Person with ID: {person.PeopleID}. ex: {ex.ToString()}");
            }
        }

        public async Task UpdatePlanetAsync(Planet planet)
        {
            try
            {
                database.Planets.Update(planet);
                await database.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating Planet with ID: {planet.PlanetID}. ex: {ex.ToString()}");
            }
        }

        public async Task UpdateSpeciesAsync(Species species)
        {
            try
            {
                database.Species.Update(species);
                await database.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating Species with ID: {species.SpeciesID}. ex: {ex.ToString()}");
            }
        }

        public async Task UpdateStarShipAsync(StarShip ship)
        {
            try
            {
                database.StarShips.Update(ship);
                await database.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating StarShip with ID: {ship.ShipID}. ex: {ex.ToString()}");
            }
        }

        public async Task UpdateVehicleAsync(Vehicle vehicle)
        {
            try
            {
                database.Vehicles.Update(vehicle);
                await database.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating Vehicle with ID: {vehicle.VehicleID}. ex: {ex.ToString()}");
            }
        }
        #endregion

        #region Delete Methods
        public async Task DeleteFilmAsync(Film film)
        {
            try
            {
                database.Films.Remove(film);
                await database.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Deleting Film with ID: {film.FilmID}. ex: {ex.ToString()}");
            }
        }

        public async Task DeletePersonAsync(People person)
        {
            try
            {
                database.People.Remove(person);
                await database.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Deleting People with ID: {person.PeopleID}. ex: {ex.ToString()}");
            }
        }

        public async Task DeletePlanetAsync(Planet planet)
        {
            try
            {
                database.Planets.Remove(planet);
                await database.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Deleting Planet with ID: {planet.PlanetID}. ex: {ex.ToString()}");
            }
        }

        public async Task DeleteSpeciesAsync(Species species)
        {
            try
            {
                database.Species.Remove(species);
                await database.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Deleting Species with ID: {species.SpeciesID}. ex: {ex.ToString()}");
            }
        }

        public async Task DeleteStarShipAsync(StarShip ship)
        {
            try
            {
                database.StarShips.Remove(ship);
                await database.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Deleting StarShip with ID: {ship.ShipID}. ex: {ex.ToString()}");
            }
        }

        public async Task DeleteVehicleAsync(Vehicle vehicle)
        {
            try
            {
                database.Vehicles.Remove(vehicle);
                await database.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Deleting Vehicle with ID: {vehicle.VehicleID}. ex: {ex.ToString()}");
            }
        }
        #endregion
    }
}

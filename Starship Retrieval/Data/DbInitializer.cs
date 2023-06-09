using Microsoft.EntityFrameworkCore;
using StarshipRetrieval.Controllers;
using StarshipRetrieval.Models;
using System.Collections;
using System.Runtime.CompilerServices;

namespace StarshipRetrieval.Data
{ 
    public class DbInitializer
    {
        public async Task Initialize(StarWarsContext context)
        {
            SWAPIController swapiController = new SWAPIController();
            if (!context.StarShips.Any())
            {
                context.StarShips.AddRange(await swapiController.GetStarShipsAsync());
            }

            if (!context.Films.Any())
            {
                context.Films.AddRange(await swapiController.GetFilmsAsync());
            }

            if (!context.People.Any())
            {
                context.People.AddRange(await swapiController.GetPeopleAsync());
            }

            if (!context.Species.Any())
            {
                context.Species.AddRange(await swapiController.GetSpeciesAsync());
            }

            if (!context.Planets.Any())
            {
                context.Planets.AddRange(await swapiController.GetPlanetsAsync());
            }

            if (!context.Vehicles.Any())
            {
                context.Vehicles.AddRange(await swapiController.GetVehiclesAsync());
            }

            await context.SaveChangesAsync();

            Dictionary<string, StarShip> starShipList = await context.StarShips.Select(x => x).ToDictionaryAsync(x => x.Url, q => q);
            Dictionary<string, Film> filmsList = await context.Films.Select(x => x).ToDictionaryAsync(x => x.Url, q => q);
            Dictionary<string, People> peopleList = await context.People.Select(x => x).ToDictionaryAsync(x => x.Url, q => q);
            Dictionary<string, Planet> planetList = await context.Planets.Select(x => x).ToDictionaryAsync(x => x.Url, q => q);
            Dictionary<string, Species> speciesList = await context.Species.Select(x => x).ToDictionaryAsync(x => x.Url, q => q);
            Dictionary<string, Vehicle> vehicleList = await context.Vehicles.Select(x => x).ToDictionaryAsync(x => x.Url, q => q);

            if (!context.StarShips.Any(x => x.Films.Any() || x.Pilots.Any()))
            {
                foreach (StarShip ship in await context.StarShips.Select(x => x).ToListAsync())
                {
                    if (ship.filmsStrings.Any())
                    {
                        ship.Films = GetList<Film>(ship.filmsStrings, filmsList);
                    }
                    if (ship.pilotsStrings.Any())
                    {
                        ship.Pilots = GetList<People>(ship.pilotsStrings, peopleList);
                    }
                }
            }

            if (!context.Films.Any(x => x.Planets.Any()))
            {
                foreach (Film film in await context.Films.Select(x => x).ToListAsync())
                {
                    if (film.planetsStrings.Any())
                    {
                        film.Planets = GetList<Planet>(film.planetsStrings, planetList);
                    }
                }
            }

            if (!context.People.Any(x => x.HomeWorld != null || x.Films.Any() || x.Species.Any()))
            {
                foreach (People person in await context.People.Select(x => x).ToListAsync())
                {
                    if(person.homeworldString != null)
                    {
                        person.HomeWorld = context.Planets.First(x => x.Url == person.homeworldString);
                    }
                    if (person.speciesStrings.Any())
                    {
                        person.Species = GetList<Species>(person.speciesStrings, speciesList);
                    }
                    if (person.filmsStrings.Any())
                    {
                        person.Films = GetList<Film>(person.filmsStrings, filmsList);
                    }
                }
            }
            
            if (!context.Planets.Any(x => x.Residents.Any()))
            {
                foreach (Planet planet in await context.Planets.Select(x => x).ToListAsync())
                {
                    if (planet.residentsStrings.Any())
                    {
                        planet.Residents = GetList<People>(planet.residentsStrings, peopleList);
                    }
                }
            }

            if (!context.Species.Any(x => x.HomeWorld != null || x.Films.Any()))
            {
                foreach (Species currSpecies in await context.Species.Select(x => x).ToListAsync())
                {
                    if (currSpecies.homeworldString != null)
                    {
                        currSpecies.HomeWorld = context.Planets.First(x => x.Url == currSpecies.homeworldString);
                    }
                    if (currSpecies.filmsStrings.Any())
                    {
                        currSpecies.Films = GetList<Film>(currSpecies.filmsStrings, filmsList);
                    }
                }
            }

            if (!context.Vehicles.Any(x => x.Films.Any() || x.Pilots.Any()))
            {
                foreach (Vehicle vehicle in await context.Vehicles.Select(x => x).ToListAsync())
                {
                    if (vehicle.filmsStrings.Any())
                    {
                        vehicle.Films = GetList<Film>(vehicle.filmsStrings, filmsList);
                    }
                    if (vehicle.pilotsStrings.Any())
                    {
                        vehicle.Pilots = GetList<People>(vehicle.pilotsStrings, peopleList);
                    }
                }
            }

            await context.SaveChangesAsync();
        }

        private List<T> GetList<T>(ICollection<string> listOfStrings, Dictionary<string, T> checkList)
        {
            List<T> list = new List<T>();
            foreach (string currString in listOfStrings)
            {
                list.Add(checkList.First(x => x.Key == currString).Value);
            }
            return list;
        }
    }
}

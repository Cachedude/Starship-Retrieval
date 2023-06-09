using Microsoft.AspNetCore.Mvc;
using StarshipRetrieval.Models;
using Newtonsoft.Json;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace StarshipRetrieval.Controllers
{
    public class SWAPIController : Controller
    {
        public async Task<IEnumerable<StarShip>> GetStarShipsAsync()
        {
            List<StarShip> starShips = new List<StarShip>();
            string currentURL = "https://swapi.dev/api/starships/";

            while(currentURL != null)
            {
                string apiResponse = await GetNextPage(currentURL);
                var starShipPage = JsonConvert.DeserializeObject<SWAPIPage<StarShip>>(apiResponse);

                if (starShipPage != null)
                {
                    foreach (var starShip in starShipPage.results)
                    {
                        var shipID = new Uri(starShip.Url).Segments[3];
                        starShip.ShipID = int.Parse(shipID.Substring(0, shipID.Length - 1));

                        starShips.Add(starShip);
                    }

                    if (!String.IsNullOrEmpty(starShipPage.next))
                    {
                        currentURL = starShipPage.next;
                    }
                    else
                    {
                        currentURL = null;
                    }
                }
            }

            return starShips;
        }

        public async Task<IEnumerable<Film>> GetFilmsAsync()
        {
            List<Film> films = new List<Film>();
            string currentURL = "https://swapi.dev/api/films/";

            while (currentURL != null)
            {
                string apiResponse = await GetNextPage(currentURL);
                var filmsPage = JsonConvert.DeserializeObject<SWAPIPage<Film>>(apiResponse);

                if (filmsPage != null)
                {
                    foreach (var film in filmsPage.results)
                    {
                        var filmID = new Uri(film.Url).Segments[3];
                        film.FilmID = int.Parse(filmID.Substring(0, filmID.Length - 1));

                        films.Add(film);
                    }

                    if (!String.IsNullOrEmpty(filmsPage.next))
                    {
                        currentURL = filmsPage.next;
                    }
                    else
                    {
                        currentURL = null;
                    }
                }
            }

            return films;
        }

        public async Task<IEnumerable<People>> GetPeopleAsync()
        {
            List<People> people = new List<People>();
            string currentURL = "https://swapi.dev/api/people/";

            while (currentURL != null)
            {
                string apiResponse = await GetNextPage(currentURL);
                var peoplePage = JsonConvert.DeserializeObject<SWAPIPage<People>>(apiResponse);

                if (peoplePage != null)
                {
                    foreach (var person in peoplePage.results)
                    {
                        var peopleID = new Uri(person.Url).Segments[3];
                        person.PeopleID = int.Parse(peopleID.Substring(0, peopleID.Length - 1));

                        people.Add(person);
                    }

                    if (!String.IsNullOrEmpty(peoplePage.next))
                    {
                        currentURL = peoplePage.next;
                    }
                    else
                    {
                        currentURL = null;
                    }
                }
            }

            return people;
        }

        public async Task<IEnumerable<Species>> GetSpeciesAsync()
        {
            List<Species> species = new List<Species>();
            string currentURL = "https://swapi.dev/api/species/";

            while (currentURL != null)
            {
                string apiResponse = await GetNextPage(currentURL);
                var speciesPage = JsonConvert.DeserializeObject<SWAPIPage<Species>>(apiResponse);

                if (speciesPage != null)
                {
                    foreach (var currentSpecies in speciesPage.results)
                    {
                        var currentSpeciesID = new Uri(currentSpecies.Url).Segments[3];
                        currentSpecies.SpeciesID = int.Parse(currentSpeciesID.Substring(0, currentSpeciesID.Length - 1));

                        species.Add(currentSpecies);
                    }

                    if (!String.IsNullOrEmpty(speciesPage.next))
                    {
                        currentURL = speciesPage.next;
                    }
                    else
                    {
                        currentURL = null;
                    }
                }
            }

            return species;
        }

        public async Task<IEnumerable<Planet>> GetPlanetsAsync()
        {
            List<Planet> planets = new List<Planet>();
            string currentURL = "https://swapi.dev/api/planets/";

            while (currentURL != null)
            {
                string apiResponse = await GetNextPage(currentURL);
                var planetsPage = JsonConvert.DeserializeObject<SWAPIPage<Planet>>(apiResponse);

                if (planetsPage != null)
                {
                    foreach (var planet in planetsPage.results)
                    {
                        var planetID = new Uri(planet.Url).Segments[3];
                        planet.PlanetID = int.Parse(planetID.Substring(0, planetID.Length - 1));

                        planets.Add(planet);
                    }

                    if (!String.IsNullOrEmpty(planetsPage.next))
                    {
                        currentURL = planetsPage.next;
                    }
                    else
                    {
                        currentURL = null;
                    }
                }
            }

            return planets;
        }

        public async Task<IEnumerable<Vehicle>> GetVehiclesAsync()
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            string currentURL = "https://swapi.dev/api/vehicles/";

            while (currentURL != null)
            {
                string apiResponse = await GetNextPage(currentURL);
                var vehiclesPage = JsonConvert.DeserializeObject<SWAPIPage<Vehicle>>(apiResponse);

                if (vehiclesPage != null)
                {
                    foreach (var vehicle in vehiclesPage.results)
                    {
                        var vehicleID = new Uri(vehicle.Url).Segments[3];
                        vehicle.VehicleID = int.Parse(vehicleID.Substring(0, vehicleID.Length - 1));

                        vehicles.Add(vehicle);
                    }

                    if (!String.IsNullOrEmpty(vehiclesPage.next))
                    {
                        currentURL = vehiclesPage.next;
                    }
                    else
                    {
                        currentURL = null;
                    }
                }
            }

            return vehicles;
        }

        private async Task<string> GetNextPage(string Url)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(Url))
                {
                    return await response.Content.ReadAsStringAsync();                    
                }
            }
        }
    }
}

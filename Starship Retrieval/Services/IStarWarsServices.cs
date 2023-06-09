using StarshipRetrieval.Models;

namespace StarshipRetrieval.Services
{
    public interface IStarWarsServices
    {
        // StarShip
        Task<List<StarShip>> GetStarShipsAsync(bool includePilots = false, bool includeFilms = false);
        Task<StarShip> GetStarShipsAsync(int shipID, bool includePilots = false, bool includeFilms = false);
        Task AddStarShipAsync(StarShip ship);
        Task UpdateStarShipAsync(StarShip ship);
        Task DeleteStarShipAsync(StarShip ship);

        // Film
        Task<List<Film>> GetFilmsAsync(bool includeSpecies = false, bool includeStarShips = false, bool includeCharacters = false, bool includeVehicles = false, bool includePlanets = false);
        Task<Film> GetFilmsAsync(int filmID, bool includeSpecies = false, bool includeStarShips = false, bool includeCharacters = false, bool includeVehicles = false, bool includePlanets = false);
        Task AddFilmAsync(Film film);
        Task UpdateFilmAsync(Film film);
        Task DeleteFilmAsync(Film film);

        // People
        Task<List<People>> GetPeopleAsync(bool includeSpecies = false, bool includeFilms = false, bool includeStarShips = false, bool includeVehicles = false);
        Task<People> GetPeopleAsync(int personID, bool includeSpecies = false, bool includeFilms = false, bool includeStarShips = false, bool includeVehicles = false);
        Task AddPersonAsync(People ship);
        Task UpdatePersonAsync(People ship);
        Task DeletePersonAsync(People ship);

        // Species
        Task<List<Species>> GetSpeciesAsync(bool includePeople = false, bool includeFilms = false);
        Task<Species> GetSpeciesAsync(int speciesID, bool includePeople = false, bool includeFilms = false);
        Task AddSpeciesAsync(Species species);
        Task UpdateSpeciesAsync(Species species);
        Task DeleteSpeciesAsync(Species species);

        // Planets
        Task<List<Planet>> GetPlanetsAsync(bool includePilots = false, bool includeFilms = false);
        Task<Planet> GetPlanetsAsync(int planetID, bool includePilots = false, bool includeFilms = false);
        Task AddPlanetAsync(Planet planet);
        Task UpdatePlanetAsync(Planet planet);
        Task DeletePlanetAsync(Planet planet);

        // Vehicles
        Task<List<Vehicle>> GetVehiclesAsync(bool includePilots = false, bool includeFilms = false);
        Task<Vehicle> GetVehiclesAsync(int vehicleID, bool includePilots = false, bool includeFilms = false);
        Task AddVehicleAsync(Vehicle vehicle);
        Task UpdateVehicleAsync(Vehicle vehicle);
        Task DeleteVehicleAsync(Vehicle vehicle);
    }
}

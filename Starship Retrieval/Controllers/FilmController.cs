using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StarshipRetrieval.Models;
using StarshipRetrieval.Services;

namespace StarshipRetrieval.Controllers
{
    [ApiController]
    [Route("api/film")]
    public class FilmController : ControllerBase
    {
        private readonly IStarWarsServices stServices;

        public FilmController(IStarWarsServices stServices)
        {
            this.stServices = stServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetFilmsAsync(bool includeSpecies = false, bool includeStarShips = false, bool includeCharacters = false, bool includeVehicles = false, bool includePlanets = false)
        {
            var films = await stServices.GetFilmsAsync(includeSpecies, includeStarShips, includeCharacters, includeVehicles, includePlanets);

            if (films == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No films in database");
            }

            return Ok(JsonConvert.SerializeObject(films));
        }

        [HttpGet("filmID")]
        public async Task<IActionResult> GetFilmsAsync(int filmID, bool includeSpecies = false, bool includeStarShips = false, bool includeCharacters = false, bool includeVehicles = false, bool includePlanets = false)
        {
            var film = await stServices.GetFilmsAsync(filmID, includeSpecies, includeStarShips, includeCharacters, includeVehicles, includePlanets);

            if (film == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No starship with ID: {filmID} in database");
            }

            return Ok(JsonConvert.SerializeObject(film));
        }

        [HttpPost]
        public async Task<ActionResult<Film>> AddFilmAsync(Film film)
        {
            try
            {
                film.DateCreated = DateTime.Now;
                film.DateEdited = DateTime.Now;
                await stServices.AddFilmAsync(film);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{film.Title} could not be added");
            }

            return Ok(film);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFilmAsync(Film film)
        {
            try
            {
                film.DateEdited = DateTime.Now;
                await stServices.UpdateFilmAsync(film);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{film.Title} could not be updated");
            }

            return Ok(film);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFilmAsync(Film film)
        {
            try
            {
                await stServices.DeleteFilmAsync(film);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{film.Title} could not be updated");
            }

            return Ok();
        }
    }
}

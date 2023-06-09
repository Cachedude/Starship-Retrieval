using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StarshipRetrieval.Models;
using StarshipRetrieval.Services;

namespace StarshipRetrieval.Controllers
{
    [ApiController]
    [Route("api/planet")]
    public class PlanetController : ControllerBase
    {
        private readonly IStarWarsServices stServices;

        public PlanetController(IStarWarsServices stServices)
        {
            this.stServices = stServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetPlanetsAsync(bool includePilots = false, bool includeFilms = false)
        {
            var planets = await stServices.GetPlanetsAsync(includePilots, includeFilms);

            if (planets == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No planets in database");
            }


            return Ok(JsonConvert.SerializeObject(planets));
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetPlanetsAsync(int planetID, bool includePilots = false, bool includeFilms = false)
        {
            var planet = await stServices.GetPlanetsAsync(planetID, includePilots, includeFilms);

            if (planet == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No planet with ID: {planetID} in database");
            }


            return Ok(JsonConvert.SerializeObject(planet));
        }

        [HttpPost]
        public async Task<ActionResult<Planet>> AddPlanetAsync(Planet planet)
        {
            try
            {
                planet.DateCreated = DateTime.Now;
                planet.DateEdited = DateTime.Now;
                await stServices.AddPlanetAsync(planet);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{planet.Name} could not be added");
            }

            return Ok(planet);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePlanetAsync(Planet planet)
        {
            try
            {
                planet.DateEdited = DateTime.Now;
                await stServices.UpdatePlanetAsync(planet);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{planet.Name} could not be updated");
            }

            return Ok(planet);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePlanetAsync(Planet planet)
        {
            try
            {
                await stServices.DeletePlanetAsync(planet);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{planet.Name} could not be updated");
            }

            return Ok();
        }
    }
}

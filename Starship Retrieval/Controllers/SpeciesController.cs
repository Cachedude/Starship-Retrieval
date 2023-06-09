using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StarshipRetrieval.Models;
using StarshipRetrieval.Services;

namespace StarshipRetrieval.Controllers
{
    [ApiController]
    [Route("api/species")]
    public class SpeciesController : ControllerBase
    {
        private readonly IStarWarsServices stServices;

        public SpeciesController(IStarWarsServices stServices)
        {
            this.stServices = stServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetSpeciesAsync(bool includePeople = false, bool includeFilms = false)
        {
            var species = await stServices.GetSpeciesAsync(includePeople, includeFilms);

            if (species == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No species in database");
            }

            return Ok(JsonConvert.SerializeObject(species));
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetSpeciesAsync(int speciesID, bool includePeople = false, bool includeFilms = false)
        {
            var species = await stServices.GetSpeciesAsync(speciesID, includePeople, includeFilms);

            if (species == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No species with ID: {speciesID} in database");
            }

            return Ok(JsonConvert.SerializeObject(species));
        }

        [HttpPost]
        public async Task<ActionResult<Species>> AddSpeciesAsync(Species species)
        {
            try
            {
                species.DateCreated = DateTime.Now;
                species.DateEdited = DateTime.Now;
                await stServices.AddSpeciesAsync(species);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{species.Name} could not be added");
            }

            return Ok(species);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSpeciesAsync(Species species)
        {
            try
            {
                species.DateEdited = DateTime.Now;
                await stServices.UpdateSpeciesAsync(species);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{species.Name} could not be updated");
            }

            return Ok(species);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSpeciesAsync(Species species)
        {
            try
            {
                await stServices.DeleteSpeciesAsync(species);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{species.Name} could not be updated");
            }

            return Ok();
        }
    }
}

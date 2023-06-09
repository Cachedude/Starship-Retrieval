using Microsoft.AspNetCore.Mvc;
using StarshipRetrieval.Services;
using StarshipRetrieval.Models;
using Newtonsoft.Json;

namespace StarshipRetrieval.Controllers
{
    [ApiController]
    [Route("api/starship")]
    public class StarshipController : ControllerBase
    {
        private readonly IStarWarsServices stServices;

        public StarshipController(IStarWarsServices stServices)
        {
            this.stServices = stServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetStarShipsAsync(bool includePilots = false, bool includeFilms = false)
        {
            var starShips = await stServices.GetStarShipsAsync(includePilots, includeFilms);

            if (starShips == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No starships in database");
            }

            return Ok(JsonConvert.SerializeObject(starShips));
        }

        [HttpGet("shipID")]
        public async Task<IActionResult> GetStarShipsAsync(int shipID, bool includePilots = false, bool includeFilms = false)
        {
            var starShip = await stServices.GetStarShipsAsync(shipID, includePilots, includeFilms);

            if (starShip == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No starship with ID: {shipID} in database");
            }

            return Ok(JsonConvert.SerializeObject(starShip));
        }

        [HttpPost]
        public async Task<ActionResult<StarShip>> AddStarShipAsync(StarShip starShip)
        {
            try
            {
                starShip.DateCreated = DateTime.Now;
                starShip.DateEdited = DateTime.Now;
                await stServices.AddStarShipAsync(starShip);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{starShip.Name} could not be added");
            }

            return Ok(starShip);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStarShipAsync(StarShip starShip)
        {
            try
            {
                starShip.DateEdited = DateTime.Now;
                await stServices.UpdateStarShipAsync(starShip);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{starShip.Name} could not be updated");
            }

            return Ok(starShip);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStarShipAsync(StarShip starShip)
        {
            try
            {
                await stServices.DeleteStarShipAsync(starShip);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{starShip.Name} could not be updated");
            }

            return Ok();
        }
    }
}

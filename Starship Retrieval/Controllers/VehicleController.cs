using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StarshipRetrieval.Models;
using StarshipRetrieval.Services;

namespace StarshipRetrieval.Controllers
{
    [ApiController]
    [Route("api/vehicle")]
    public class VehicleController : ControllerBase
    {
        private readonly IStarWarsServices stServices;

        public VehicleController(IStarWarsServices stServices)
        {
            this.stServices = stServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetVehiclesAsync(bool includePilots = false, bool includeFilms = false)
        {
            var vehicles = await stServices.GetVehiclesAsync(includePilots, includeFilms);

            if (vehicles == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No vehicles in database");
            }

            return Ok(JsonConvert.SerializeObject(vehicles));
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetVehiclesAsync(int vehicleID, bool includePilots = false, bool includeFilms = false)
        {
            var vehicle = await stServices.GetVehiclesAsync(vehicleID, includePilots, includeFilms);

            if (vehicle == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No vehicle with ID: {vehicleID} in database");
            }

            return Ok(JsonConvert.SerializeObject(vehicle));
        }

        [HttpPost]
        public async Task<ActionResult<Vehicle>> AddVehicleAsync(Vehicle vehicle)
        {
            try
            {
                vehicle.DateCreated = DateTime.Now;
                vehicle.DateEdited = DateTime.Now;
                await stServices.AddVehicleAsync(vehicle);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{vehicle.Name} could not be added");
            }

            return Ok(vehicle);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateVehicleAsync(Vehicle vehicle)
        {
            try
            {
                vehicle.DateEdited = DateTime.Now;
                await stServices.UpdateVehicleAsync(vehicle);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{vehicle.Name} could not be updated");
            }

            return Ok(vehicle);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteVehicleAsync(Vehicle vehicle)
        {
            try
            {
                await stServices.DeleteVehicleAsync(vehicle);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{vehicle.Name} could not be updated");
            }

            return Ok();
        }
    }
}

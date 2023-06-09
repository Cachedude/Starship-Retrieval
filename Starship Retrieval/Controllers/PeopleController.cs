using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StarshipRetrieval.Models;
using StarshipRetrieval.Services;

namespace StarshipRetrieval.Controllers
{
    [ApiController]
    [Route("api/people")]
    public class PeopleController : ControllerBase
    {
        private readonly IStarWarsServices stServices;

        public PeopleController(IStarWarsServices stServices)
        {
            this.stServices = stServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetPeopleAsync(bool includeSpecies = false, bool includeFilms = false, bool includeStarShips = false, bool includeVehicles = false)
        {
            var persons = await stServices.GetPeopleAsync(includeSpecies, includeFilms, includeStarShips, includeVehicles);

            if (persons == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No people in database");
            }

            return Ok(JsonConvert.SerializeObject(persons));
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetPeopleAsync(int personID, bool includeSpecies = false, bool includeFilms = false, bool includeStarShips = false, bool includeVehicles = false)
        {
            var person = await stServices.GetPeopleAsync(personID, includeSpecies, includeFilms, includeStarShips, includeVehicles);

            if (person == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No person with ID: {personID} in database");
            }


            return Ok(JsonConvert.SerializeObject(person));
        }

        [HttpPost]
        public async Task<ActionResult<People>> AddPersonAsync(People person)
        {
            try
            {
                person.DateCreated = DateTime.Now;
                person.DateEdited = DateTime.Now;
                await stServices.AddPersonAsync(person);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{person.Name} could not be added");
            }

            return Ok(person);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePersonAsync(People person)
        {
            try
            {
                person.DateEdited = DateTime.Now;
                await stServices.UpdatePersonAsync(person);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{person.Name} could not be updated");
            }

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePersonAsync(People person)
        {
            try
            {
                await stServices.DeletePersonAsync(person);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{person.Name} could not be updated");
            }

            return Ok();
        }
    }
}

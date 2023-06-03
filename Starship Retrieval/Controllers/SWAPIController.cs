using Microsoft.AspNetCore.Mvc;
using StarshipRetrieval.Models;
using Newtonsoft.Json;
using System.Net.Http;

namespace StarshipRetrieval.Controllers
{
    public class SWAPIController : Controller
    {
        public async Task<IEnumerable<StarShip>> GetStarShipsAsync()
        {
            return await GetNextPage("https://swapi.dev/api/starships/");
        }

        private async Task<IEnumerable<StarShip>> GetNextPage(string Url)
        {
            List<StarShip> starShips = new List<StarShip>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(Url))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var starShipPage = JsonConvert.DeserializeObject<StarShipPage>(apiResponse);

                    if (starShipPage != null)
                    {
                        foreach (var starShip in starShipPage.results)
                        {
                            var id = new Uri(starShip.Url).Segments[3];
                            starShip.ID = int.Parse(id.Substring(0, id.Length - 1));
                            starShips.Add(starShip);
                        }

                        if (!String.IsNullOrEmpty(starShipPage.next))
                        {
                            starShips.AddRange(await GetNextPage(starShipPage.next));
                        }
                    }
                }
            }
            return starShips;
        }
    }
}

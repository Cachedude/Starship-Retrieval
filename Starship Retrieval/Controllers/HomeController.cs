using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using StarshipRetrieval.Models;
using System.Diagnostics;

namespace StarshipRetrieval.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMemoryCache memoryCache;

        private int SelectedStarShipID { get; set; }
        private List<StarShip> StarShips { get; set; }

        public HomeController(IMemoryCache memoryCache, ILogger<HomeController> logger)
        {
            this.memoryCache = memoryCache;
            _logger = logger;
            Random r = new Random();
            SelectedStarShipID = r.Next(0, 36);
        }

        public async Task LoadStarShipsAsync()
        {
            var cacheKey = "starshipList";
            if (!memoryCache.TryGetValue(cacheKey, out List<StarShip> starShips))
                {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("https://localhost:44387/api/starship?includeFilms=true&includePilots=true"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        starShips = JsonConvert.DeserializeObject<List<StarShip>>(apiResponse);
                    }
                }

                var cacheExpiryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddSeconds(5000),
                    Priority = CacheItemPriority.High,
                    SlidingExpiration = TimeSpan.FromSeconds(2000)
                };

                memoryCache.Set(cacheKey, starShips, cacheExpiryOptions);
            }
            StarShips = starShips;
        }


        public async Task<IActionResult> Index()
        {
            await LoadStarShipsAsync();
            ViewBag.StarShips = StarShips;
            return View(SelectedStarShipID);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public async Task<IActionResult> SetStarShip(int id)
        {
            SelectedStarShipID = id - 1;
            await LoadStarShipsAsync();
            ViewBag.StarShips = StarShips;
            return View("Index", SelectedStarShipID);
        }
    }
}
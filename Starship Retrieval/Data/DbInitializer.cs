using StarshipRetrieval.Controllers;
using StarshipRetrieval.Models;

namespace StarshipRetrieval.Data
{
    public class DbInitializer
    {
        public async void InitializeAsync(StarWarsContext context)
        {
            SWAPIController swapiController = new SWAPIController();
            var starShips = await swapiController.GetStarShipsAsync();

            context.Database.EnsureCreated();

            if (context.StarShips.Any())
            {
                return;
            }

            foreach(var starShip in starShips)
            {
                context.StarShips.Add(starShip);
            }
            context.SaveChanges();
        }
    }
}

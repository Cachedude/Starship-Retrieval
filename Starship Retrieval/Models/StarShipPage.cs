namespace StarshipRetrieval.Models
{
    public class StarShipPage
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public ICollection<StarShip> results { get; set; }
    }
}

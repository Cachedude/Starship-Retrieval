namespace StarshipRetrieval.Models
{
    public class Film
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int EpisodeID { get; set; }
        public string OpeningCrawl { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ICollection<Species> Species { get; set; }
        public ICollection<StarShip> StarShips { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
        public ICollection<People> Characters { get; set; }
        public ICollection<Planet> Planets { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateEdited { get; set; }
        public string Url { get; set; }

    }
}

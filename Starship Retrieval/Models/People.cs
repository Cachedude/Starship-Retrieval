namespace StarshipRetrieval.Models
{
    public class People
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string BirthYear { get; set; }
        public string EyeColor { get; set; }
        public string Gender { get; set; }
        public string HairColor { get; set; }
        public long Height { get; set; }
        public long Mass { get; set; }
        public string SkinColor { get; set; }
        public Planet HomeWorld { get; set; }
        public ICollection<Film> Films { get; set; }
        public ICollection<Species> Species { get; set; }
        public ICollection<StarShip> StarShips { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateEdited { get; set; }
        public string Url { get; set; }
    }
}

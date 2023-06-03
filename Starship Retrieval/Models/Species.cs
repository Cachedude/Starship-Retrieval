namespace StarshipRetrieval.Models
{
    public class Species
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Classification { get; set; }
        public string Designation { get; set; }
        public int AverageHeight { get; set; }
        public string SkinColors { get; set; }
        public string HairColors { get; set; }
        public string EyeColors { get; set; }
        public int AverageLifespan { get; set; }
        public Planet HomeWorld { get; set; }
        public string Language { get; set; }
        public ICollection<Film> Films { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateEdited { get; set; }
        public string Url { get; set; }
    }
}

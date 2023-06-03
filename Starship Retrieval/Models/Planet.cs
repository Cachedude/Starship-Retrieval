namespace StarshipRetrieval.Models
{
    public class Planet
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int RotationPeriod { get; set; }
        public int OrbitalPeriod { get; set; }
        public long Diameter { get; set; }
        public string Climate { get; set; }
        public string Gravity { get; set; }
        public string Terrain { get; set; }
        public string SurfaceWater { get; set; }
        public int Population { get; set; }
        public ICollection<People> Residents { get; set; }
        public ICollection<Film> Films { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateEdited { get; set; }
        public string Url { get; set; }
    }
}

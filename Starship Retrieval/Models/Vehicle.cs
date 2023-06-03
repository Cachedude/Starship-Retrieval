namespace StarshipRetrieval.Models
{
    public class Vehicle
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public int CostInCredits { get; set; }
        public long Length { get; set; }
        public long MaxAtmospheringSpeed { get; set; }
        public int Crew { get; set; }
        public int Passengers { get; set; }
        public int CargoCapacity { get; set; }
        public string Consumables { get; set; }
        public string VehicleClass { get; set; }
        public ICollection<People> Pilots { get; set; }
        public ICollection<Film> Films { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateEdited { get; set; }
        public string Url { get; set; }
    }
}

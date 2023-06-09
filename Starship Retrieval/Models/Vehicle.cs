using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarshipRetrieval.Models
{
    public class Vehicle
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("vehicleID")]
        public int VehicleID { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("model")]
        public string? Model { get; set; }

        [JsonProperty("manufacturer")]
        public string? Manufacturer { get; set; }

        [JsonProperty("cost_in_credits")]
        public string? CostInCredits { get; set; }

        [JsonProperty("length")]
        public string? Length { get; set; }

        [JsonProperty("max_atmosphering_speed")]
        public string? MaxAtmospheringSpeed { get; set; }

        [JsonProperty("crew")]
        public string? Crew { get; set; }

        [JsonProperty("passengers")]
        public string? Passengers { get; set; }

        [JsonProperty("cargo_capacity")]
        public string? CargoCapacity { get; set; }

        [JsonProperty("consumables")]
        public string? Consumables { get; set; }

        [JsonProperty("vehicle_class")]
        public string? VehicleClass { get; set; }

        [JsonProperty("pilots")]
        public ICollection<string> pilotsStrings { get; set; }

        [JsonProperty("pilots_Objects")]
        public ICollection<People>? Pilots { get; set; }

        [JsonProperty("films")]
        public ICollection<string> filmsStrings { get; set; }

        [JsonProperty("films_Objects")]
        public ICollection<Film>? Films { get; set; }

        [JsonProperty("created")]
        public DateTime DateCreated { get; set; }

        [JsonProperty("edited")]
        public DateTime DateEdited { get; set; }
        
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}

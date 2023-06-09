using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarshipRetrieval.Models
{
    public class Planet
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("planetID")]
        public int PlanetID { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("rotation_period")]
        public string? RotationPeriod { get; set; }

        [JsonProperty("orbital_period")]
        public string? OrbitalPeriod { get; set; }

        [JsonProperty("diameter")]
        public string? Diameter { get; set; }

        [JsonProperty("climate")]
        public string? Climate { get; set; }

        [JsonProperty("gravity")]
        public string? Gravity { get; set; }

        [JsonProperty("terrain")]
        public string? Terrain { get; set; }

        [JsonProperty("surface_water")]
        public string? SurfaceWater { get; set; }

        [JsonProperty("population")]
        public string? Population { get; set; }

        [JsonProperty("residents")]
        public ICollection<string> residentsStrings { get; set; }

        [JsonIgnore]
        [JsonProperty("residents_Object")]
        public ICollection<People>? Residents { get; set; }

        [JsonProperty("films")]
        public ICollection<string> filmsStrings { get; set; }

        [JsonProperty("films_Object")]
        public ICollection<Film>? Films { get; set; }

        [JsonProperty("created")]
        public DateTime DateCreated { get; set; }

        [JsonProperty("edited")]
        public DateTime DateEdited { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}

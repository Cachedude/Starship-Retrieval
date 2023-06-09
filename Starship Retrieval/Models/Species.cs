using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarshipRetrieval.Models
{
    public class Species
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("speciesID")]
        public int SpeciesID { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("classification")]
        public string? Classification { get; set; }

        [JsonProperty("designation")]
        public string? Designation { get; set; }

        [JsonProperty("average_height")]
        public string? AverageHeight { get; set; }

        [JsonProperty("skin_colors")]
        public string? SkinColors { get; set; }

        [JsonProperty("hair_colors")]
        public string? HairColors { get; set; }

        [JsonProperty("eye_colors")]
        public string? EyeColors { get; set; }

        [JsonProperty("average_lifespan")]
        public string? AverageLifespan { get; set; }

        [JsonProperty("homeworld")]
        public string? homeworldString { get; set; }

        [JsonProperty("homeworld_Object")]
        public Planet? HomeWorld { get; set; }

        [JsonProperty("language")]
        public string? Language { get; set; }

        [JsonProperty("films")]
        public ICollection<string> filmsStrings { get; set; }

        [JsonProperty("films_Object")]
        public ICollection<Film>? Films { get; set; }

        [JsonProperty("people")]
        public ICollection<string> peopleStrings { get; set; }

        [JsonProperty("people_Object")]
        public ICollection<People>? People { get; set; }

        [JsonProperty("created")]
        public DateTime DateCreated { get; set; }

        [JsonProperty("edited")]
        public DateTime DateEdited { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}

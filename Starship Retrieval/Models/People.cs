using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarshipRetrieval.Models
{
    public class People
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("peopleID")]
        public int PeopleID { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("birth_year")]
        public string? BirthYear { get; set; }

        [JsonProperty("eye_color")]
        public string? EyeColor { get; set; }

        [JsonProperty("gender")]
        public string? Gender { get; set; }

        [JsonProperty("hair_color")]
        public string? HairColor { get; set; }

        [JsonProperty("height")]
        public string? Height { get; set; }

        [JsonProperty("mass")]
        public string? Mass { get; set; }

        [JsonProperty("skin_color")]
        public string? SkinColor { get; set; }

        [JsonProperty("homeworld")]
        public string? homeworldString { get; set; }

        [JsonProperty("homeworld_Object")]
        public Planet? HomeWorld { get; set; }

        [JsonProperty("films")]
        public ICollection<string> filmsStrings { get; set; }

        [JsonProperty("films_Object")]
        public ICollection<Film>? Films { get; set; }

        [JsonProperty("species")]
        public ICollection<string> speciesStrings { get; set; }

        [JsonProperty("species_Object")]
        public ICollection<Species>? Species { get; set; }

        [JsonProperty("starships")]
        public ICollection<string> starShipsStrings { get; set; }

        [JsonIgnore]
        [JsonProperty("starships_Object")]
        public ICollection<StarShip>? StarShips { get; set; }

        [JsonProperty("vehicles")]
        public ICollection<string> vehiclesStrings { get; set; }

        [JsonProperty("vehicles_Object")]
        public ICollection<Vehicle>? Vehicles { get; set; }

        [JsonProperty("created")]
        public DateTime DateCreated { get; set; }

        [JsonProperty("edited")]
        public DateTime DateEdited { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}

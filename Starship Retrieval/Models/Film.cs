using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarshipRetrieval.Models
{
    public class Film
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("filmID")]
        public int FilmID { get; set; }

        [JsonProperty("title")]
        public string? Title { get; set; }

        [JsonProperty("episode_id")]
        public int EpisodeID { get; set; }

        [JsonProperty("opening_crawl")]
        public string? OpeningCrawl { get; set; }

        [JsonProperty("director")]
        public string? Director { get; set; }

        [JsonProperty("producer")]
        public string? Producer { get; set; }

        [JsonProperty("release_date")]
        public DateTime ReleaseDate { get; set; }

        [JsonProperty("species")]
        public List<string> speciesStrings { get; set; }

        [JsonProperty("species_Objects")]
        public ICollection<Species>? Species { get; set; }

        [JsonProperty("starships")]
        public List<string> starShipsStrings { get; set; }

        [JsonIgnore]
        [JsonProperty("starships_Objects")]
        public ICollection<StarShip>? StarShips { get; set; }

        [JsonProperty("vehicles")]
        public List<string> vehiclesStrings { get; set; }

        [JsonProperty("vehicles_Objects")]
        public ICollection<Vehicle>? Vehicles { get; set; }

        [JsonProperty("characters")]
        public List<string> charactersStrings { get; set; }

        [JsonProperty("characters_Objects")]
        public ICollection<People>? Characters { get; set; }

        [JsonProperty("planets")]
        public List<string> planetsStrings { get; set; }

        [JsonProperty("planets_Objects")]
        public ICollection<Planet>? Planets { get; set; }

        [JsonProperty("created")]
        public DateTime DateCreated { get; set; }

        [JsonProperty("edited")]
        public DateTime DateEdited { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

    }
}

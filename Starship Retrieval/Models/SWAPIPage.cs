namespace StarshipRetrieval.Models
{
    public class SWAPIPage<T>
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public ICollection<T> results { get; set; }
    }
}

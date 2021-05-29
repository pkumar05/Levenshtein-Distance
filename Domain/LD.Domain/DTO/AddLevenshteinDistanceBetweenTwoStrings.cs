namespace LD.Domain.DTO
{
    public class AddLevenshteinDistanceBetweenTwoStrings
    {
        public string Source { get; set; }
        public string Target { get; set; }

        public int LevenshteinDistanceVal { get; set; }

    }
}

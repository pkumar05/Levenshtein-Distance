using System.ComponentModel.DataAnnotations;

namespace LD.Domain.DTO
{
    public class FindLevenshteinDistanceRequest
    {
        [Required]
        public string Source { get; set; }
        [Required]
        public string Target { get; set; }
    }
}

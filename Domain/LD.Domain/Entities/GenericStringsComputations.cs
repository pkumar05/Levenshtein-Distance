using SD.BuildingBlocks.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;

namespace LD.Domain.Entities
{
    [Table("GenericStringsComputations", Schema = "LD")]
    public class GenericStringsComputations : BaseEntity   //GenericStringsComputations
    {
        public string Source { get; set; }
        public string Target { get; set; }

        public int LevenshteinDistance { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }



    }
}

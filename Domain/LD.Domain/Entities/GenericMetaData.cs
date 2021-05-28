using SD.BuildingBlocks.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;

namespace LD.Domain.Entities
{
    [Table("GenericMetaData", Schema = "LD")]
    public class GenericMetaData : BaseEntity
    {
        public string MetaSource { get; set; }
        public string MetaType { get; set; }
        public string MetaData { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public bool Active { get; set; }
    }
}

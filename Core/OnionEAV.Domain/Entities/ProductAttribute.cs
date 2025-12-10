using System.Collections.Generic;

namespace OnionEAV.Domain.Entities
{
    public class ProductAttribute : BaseEntity
    {
        public string Name { get; set; }
        public string DataType { get; set; }
        public bool IsRequired { get; set; }
        public int? CategoryId { get; set; }
        public int DisplayOrder { get; set; }
        public string Description { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<ProductAttributeValue> ProductAttributeValues { get; set; }
    }
}

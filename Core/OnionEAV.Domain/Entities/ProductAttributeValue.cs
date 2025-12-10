namespace OnionEAV.Domain.Entities
{
    public class ProductAttributeValue : BaseEntity
    {
        public int ProductId { get; set; }
        public int ProductAttributeId { get; set; }
        public string Value { get; set; }

        public virtual Product Product { get; set; }
        public virtual ProductAttribute ProductAttribute { get; set; }
    }
}

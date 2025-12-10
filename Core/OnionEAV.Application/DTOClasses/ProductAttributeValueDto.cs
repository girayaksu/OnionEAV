namespace OnionEAV.Application.DTOClasses
{
    public class ProductAttributeValueDto : BaseDto
    {
        public int ProductId { get; set; }
        public int ProductAttributeId { get; set; }
        public string Value { get; set; }
        public string ProductName { get; set; }
        public string AttributeName { get; set; }
    }
}

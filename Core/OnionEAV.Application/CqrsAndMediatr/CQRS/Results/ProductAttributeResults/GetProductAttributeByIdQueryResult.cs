namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Results.ProductAttributeResults
{
    public class GetProductAttributeByIdQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DataType { get; set; }
        public bool IsRequired { get; set; }
        public int? CategoryId { get; set; }
        public int DisplayOrder { get; set; }
        public string Description { get; set; }
    }
}

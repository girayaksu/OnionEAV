namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Results.ProductAttributeValueResults
{
    public class GetProductAttributeValueQueryResult
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ProductAttributeId { get; set; }
        public string Value { get; set; }
        public string ProductName { get; set; }
        public string AttributeName { get; set; }
    }
}

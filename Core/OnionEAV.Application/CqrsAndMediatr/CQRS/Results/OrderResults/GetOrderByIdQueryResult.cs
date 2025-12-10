namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Results.OrderResults
{
    public class GetOrderByIdQueryResult
    {
        public int Id { get; set; }
        public string ShippingAddress { get; set; }
        public int? AppUserId { get; set; }
    }
}
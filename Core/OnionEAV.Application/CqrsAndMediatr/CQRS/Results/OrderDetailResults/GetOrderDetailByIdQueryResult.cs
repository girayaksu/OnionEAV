namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Results.OrderDetailResults
{
    public class GetOrderDetailByIdQueryResult
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
    }
}
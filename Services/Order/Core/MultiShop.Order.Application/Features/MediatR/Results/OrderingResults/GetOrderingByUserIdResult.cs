namespace MultiShop.Order.Application.Features.MediatR.Results
{
    public class GetOrderingByUserIdResult
    {
        public int OrderingId { get; set; }
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}

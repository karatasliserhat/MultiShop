using MediatR;

namespace MultiShop.Order.Application.Features.MediatR.Commands
{
    public class CreateOrderDetailCommand:IRequest
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductAmount { get; set; }
        public decimal ProductTotalPrice { get; set; }
        public int OrderingId { get; set; }
    }
}

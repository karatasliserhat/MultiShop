using MediatR;

namespace MultiShop.Order.Application.Features.MediatR.Commands
{
    public class CreateOrderingCommand:IRequest
    {
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}

using MediatR;

namespace MultiShop.Order.Application.Features.MediatR.Commands
{
    public class RemoveOrderDetailCommand:IRequest
    {
        public int OrderDetailId { get; set; }

        public RemoveOrderDetailCommand(int orderDetailId)
        {
            OrderDetailId = orderDetailId;
        }
    }
}

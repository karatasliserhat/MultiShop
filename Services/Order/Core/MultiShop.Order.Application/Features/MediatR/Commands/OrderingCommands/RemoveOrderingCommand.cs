using MediatR;

namespace MultiShop.Order.Application.Features.MediatR.Commands
{
    public class RemoveOrderingCommand : IRequest
    {
        public int OrderingId { get; set; }

        public RemoveOrderingCommand(int orderingId)
        {
            OrderingId = orderingId;
        }
    }
}

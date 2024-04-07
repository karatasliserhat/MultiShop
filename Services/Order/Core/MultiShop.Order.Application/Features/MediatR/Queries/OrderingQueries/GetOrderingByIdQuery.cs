using MediatR;
using MultiShop.Order.Application.Features.MediatR.Results;

namespace MultiShop.Order.Application.Features.MediatR.Queries
{
    public class GetOrderingByIdQuery:IRequest<GetOrderingByIdQueryResult>
    {
        public int OrderingId { get; set; }

        public GetOrderingByIdQuery(int orderingId)
        {
            OrderingId = orderingId;
        }
    }
}

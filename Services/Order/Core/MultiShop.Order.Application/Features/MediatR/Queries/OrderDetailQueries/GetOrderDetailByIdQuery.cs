using MediatR;
using MultiShop.Order.Application.Features.MediatR.Results;

namespace MultiShop.Order.Application.Features.MediatR.Queries
{
    public class GetOrderDetailByIdQuery:IRequest<GetOrderDetailByIdQueryResult>
    {
        public int OrderDetailId { get; set; }

        public GetOrderDetailByIdQuery(int orderDetailId)
        {
            OrderDetailId = orderDetailId;
        }
    }
}

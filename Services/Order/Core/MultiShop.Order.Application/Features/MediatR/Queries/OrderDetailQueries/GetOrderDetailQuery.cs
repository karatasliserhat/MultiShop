using MediatR;
using MultiShop.Order.Application.Features.MediatR.Results;

namespace MultiShop.Order.Application.Features.MediatR.Queries
{
    public class GetOrderDetailQuery:IRequest<List<GetOrderDetailQueryResult>>
    {
    }
}

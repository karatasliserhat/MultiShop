using MediatR;
using MultiShop.Order.Application.Features.MediatR.Results;

namespace MultiShop.Order.Application.Features.MediatR.Queries.OrderingQueries
{
    public class GetOrderingByUserIdQuery:IRequest<List<GetOrderingByUserIdResult>>
    {
        public string UserId { get; set; }

        public GetOrderingByUserIdQuery(string userId)
        {
            UserId = userId;
        }
    }
}

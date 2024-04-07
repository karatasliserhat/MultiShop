using MediatR;
using MultiShop.Order.Application.Features.MediatR.Results;

namespace MultiShop.Order.Application.Features.MediatR.Queries
{
    public class GetAddressByIdQuery:IRequest<GetAdressByIdQueryResult>
    {
        public int AddressId { get; set; }

        public GetAddressByIdQuery(int addressId)
        {
            AddressId = addressId;
        }
    }
}

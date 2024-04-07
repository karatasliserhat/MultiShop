using MediatR;

namespace MultiShop.Order.Application.Features.MediatR.Commands
{
    public class RemoveAddressCommand:IRequest
    {
        public int AddressId { get; set; }

        public RemoveAddressCommand(int addressId)
        {
            AddressId = addressId;
        }
    }
}

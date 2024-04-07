using MediatR;

namespace MultiShop.Order.Application.Features.MediatR.Commands
{
    public class CreateAddressCommand:IRequest
    {
        public string UserId { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Detail { get; set; }
    }
}

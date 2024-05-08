using MultiShop.DtoLayer.OrderDtos;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.Shared.Services.Service
{
    public class OrderAddressCommandApiService : ApiCommandService<UpdateAddressDto, CreateAddressDto>, IOrderAddressCommandApiService
    {
        public OrderAddressCommandApiService(HttpClient client) : base(client)
        {
        }
    }
}

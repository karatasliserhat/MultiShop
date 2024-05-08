using MultiShop.DtoLayer.OrderDtos;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.Shared.Services.Service
{
    public class OrderingCommandApiService : ApiCommandService<UpdateOrderingDto, CreateOrderingDto>, IOrderingCommandApiService
    {
        public OrderingCommandApiService(HttpClient client) : base(client)
        {
        }
    }
}

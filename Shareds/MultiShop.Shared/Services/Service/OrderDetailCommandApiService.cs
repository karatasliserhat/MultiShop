using MultiShop.DtoLayer.OrderDtos;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.Shared.Services.Service
{
    public class OrderDetailCommandApiService : ApiCommandService<UpdateOrderDetailDto, CreateOrderDetailDto>, IOrderDetailCommandApiService
    {
        public OrderDetailCommandApiService(HttpClient client) : base(client)
        {
        }
    }
}

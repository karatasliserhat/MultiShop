using MultiShop.DtoLayer.OrderDtos;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.Shared.Services.Service
{
    public class OrderDetailReadApiService : ApiReadService<ResultOrderDetailDto>, IOrderDetailReadApiService
    {
        public OrderDetailReadApiService(HttpClient client) : base(client)
        {
        }
    }
}

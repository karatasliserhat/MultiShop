using MultiShop.DtoLayer.OrderDtos;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.Shared.Services.Service
{
    public class OrderingReadApiService : ApiReadService<ResultOrderingDto>, IOrderingReadApiService
    {
        public OrderingReadApiService(HttpClient client) : base(client)
        {
        }
    }
}

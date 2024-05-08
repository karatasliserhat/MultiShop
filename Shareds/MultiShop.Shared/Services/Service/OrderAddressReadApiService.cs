using MultiShop.DtoLayer.OrderDtos;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.Shared.Services.Service
{
    public class OrderAddressReadApiService : ApiReadService<ResultAddressDto>, IOrderAddressReadApiService
    {
        public OrderAddressReadApiService(HttpClient client) : base(client)
        {
        }
    }
}

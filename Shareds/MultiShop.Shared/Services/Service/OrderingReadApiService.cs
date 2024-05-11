using MultiShop.DtoLayer.OrderDtos;
using MultiShop.Shared.Services.Abstract;
using System.Net.Http.Json;

namespace MultiShop.Shared.Services.Service
{
    public class OrderingReadApiService : ApiReadService<ResultOrderingDto>, IOrderingReadApiService
    {
        private readonly HttpClient _client;
        public OrderingReadApiService(HttpClient client) : base(client)
        {
            _client = client;
        }

        public async Task<List<GetOrderingByUserIdDto>> GetAllOrderingByUserId(string userId)
        {
            var values = await _client.GetFromJsonAsync<List<GetOrderingByUserIdDto>>($"Orderings/GetOrderingByUserId/{userId}");
            if (values is not null)
            {
                return values;
            }
            return null;
        }
    }
}

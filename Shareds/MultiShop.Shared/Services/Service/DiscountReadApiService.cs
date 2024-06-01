using MultiShop.DtoLayer;
using MultiShop.Shared.Services.Abstract;
using System.Net.Http.Json;

namespace MultiShop.Shared.Services.Service
{
    public class DiscountReadApiService : ApiReadService<ResultCouponDto>, IDiscountReadApiService
    {
        private readonly HttpClient _client;
        public DiscountReadApiService(HttpClient client) : base(client)
        {
            _client = client;
        }

        public async Task<int> GetDiscountCount()
        {
            return await _client.GetFromJsonAsync<int>("Discounts/GetDiscountCount");
        }

        public async Task<ResultCouponDto> GetDiscountCouponDetailWihtCodeAsync(string code)
        {
            return await _client.GetFromJsonAsync<ResultCouponDto>($"discounts/GetCouponDetailWithCode/{code}");
        }

        public async Task<GetByCodeCouponRateDto> GetDiscountCouponRateWihtCodeAsync(string code)
        {
            return await _client.GetFromJsonAsync<GetByCodeCouponRateDto>($"discounts/GetCouponRateWithCode/{code}");
        }
    }
}

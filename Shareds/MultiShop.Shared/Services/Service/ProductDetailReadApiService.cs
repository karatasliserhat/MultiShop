using MultiShop.DtoLayer.CatalogDtos;
using MultiShop.Shared.Services.Abstract;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace MultiShop.Shared.Services.Service
{
    public class ProductDetailReadApiService : ApiReadService<ResultProductDetailDtos>, IProductDetailReadApiService
    {
        private readonly HttpClient _client;
        public ProductDetailReadApiService(HttpClient client, IAuthorizationTokenApiService authorizationTokenApiService) : base(client, authorizationTokenApiService)
        {
            _client = client;
        }

        public async Task<GetProductDetailWithProductDto> GetProductDetailByProductIdAsync(string productId)
        {
            var result = await _client.GetAsync($"ProductDetails/GetProductDetailByProductId/{productId}");
            if (result.StatusCode == HttpStatusCode.OK)
            {
                var jsonData = await result.Content.ReadAsStringAsync();

                var data = JsonSerializer.Deserialize<GetProductDetailWithProductDto>(jsonData, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
                return data;
            }
            return null;

        }

    }
}

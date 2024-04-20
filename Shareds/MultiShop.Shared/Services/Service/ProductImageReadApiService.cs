using MultiShop.DtoLayer.CatalogDtos;
using MultiShop.Shared.Services.Abstract;
using System.Net.Http.Json;

namespace MultiShop.Shared.Services.Service
{
    public class ProductImageReadApiService : ApiReadService<ResultProductImagesDto>, IProductImageReadApiService
    {
        private readonly HttpClient _httpClient;
        public ProductImageReadApiService(HttpClient client) : base(client)
        {
            _httpClient = client;
        }
        public async Task<List<GetImagesWithProductDto>> GetImagesWithProductByProductIdAsync(string productId)
        {
            return await _httpClient.GetFromJsonAsync<List<GetImagesWithProductDto>>($"ProductImages/GetImagesWithProductByProductId/{productId}");
        }
    }
}

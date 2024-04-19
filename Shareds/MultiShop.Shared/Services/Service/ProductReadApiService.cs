using MultiShop.DtoLayer.CatalogDtos;
using MultiShop.Shared.Services.Abstract;
using System.Net.Http.Json;

namespace MultiShop.Shared.Services.Service
{
    public class ProductReadApiService : ApiReadService<ResultProductDto>, IProductReadApiService
    {
        private readonly HttpClient _client;
        public ProductReadApiService(HttpClient client) : base(client)
        {
            _client = client;
        }

        public async Task<List<ResultProductsWithCategoryDto>> GetProductsWithCategoryAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultProductsWithCategoryDto>>("Products/ProductListWithCategory");

        }

        public async Task<List<ResultProductsWithCategoryDto>> ProductListWithCategoryByCategoryId(string categoryId)
        {
            return await _client.GetFromJsonAsync<List<ResultProductsWithCategoryDto>>($"Products/ProductListWithCategoryByCategoryId/{categoryId}");
        }
    }
}

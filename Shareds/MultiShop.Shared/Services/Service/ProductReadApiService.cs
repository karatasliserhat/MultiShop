using MultiShop.DtoLayer.CatalogDtos;
using MultiShop.Shared.Services.Abstract;
using System.Net.Http.Json;

namespace MultiShop.Shared.Services.Service
{
    public class ProductReadApiService : ApiReadService<ResultProductDto>, IProductReadApiService
    {
        private readonly HttpClient _client;
        public ProductReadApiService(HttpClient client, IAuthorizationTokenApiService authorizationTokenApiService) : base(client, authorizationTokenApiService)
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

        public async Task<ResultProductWithCategoryWithImagesWithDetailDto> GetResultProductWithCategoryWithImagesWithDetailByProductIdAsync(string productId)
        {
            return await _client.GetFromJsonAsync<ResultProductWithCategoryWithImagesWithDetailDto>($"Products/GetProductWithCategoryWithImagesWithDetailByProductId/{productId}");
        }

        public async Task<GetProductWithProductDetailDto> GetResultProductWithDetailByProductIdAsync(string productId)
        {
            return await _client.GetFromJsonAsync<GetProductWithProductDetailDto>($"Products/GetProductWithDetailByProductId/{productId}");
        }

        public async Task<GetProductWithProductImagesDto> GetResultProductWithImagesByProductIdAsync(string productId)
        {
            return await _client.GetFromJsonAsync<GetProductWithProductImagesDto>($"Products/GetProductWithImagesByProductId/{productId}");
        }
    }
}

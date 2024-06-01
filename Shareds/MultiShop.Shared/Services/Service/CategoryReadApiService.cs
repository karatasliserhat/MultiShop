using MultiShop.Shared.Services.Abstract;
using MultiShop.DtoLayer.CatalogDtos;
using System.Net.Http.Json;

namespace MultiShop.Shared.Services.Service
{
    public class CategoryReadApiService : ApiReadService<ResultCategoryDto>, ICategoryReadApiService
    {
        private readonly HttpClient _client;
        public CategoryReadApiService(HttpClient client) : base(client)
        {
            _client = client;
        }

        public async Task<int> GetCategoryCount()
        {
            return await _client.GetFromJsonAsync<int>("Statistics/GetCategoryCount");
        }
    }
}

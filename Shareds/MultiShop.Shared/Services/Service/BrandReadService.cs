using MultiShop.DtoLayer.CatalogDtos;
using MultiShop.Shared.Services.Abstract;
using System.Net.Http.Json;

namespace MultiShop.Shared.Services.Service
{
    public class BrandReadService : ApiReadService<ResultBrandDto>, IBrandReadApiService
    {
        private readonly HttpClient _client;
        public BrandReadService(HttpClient client) : base(client)
        {
            _client = client;
        }

        public async Task<int> GetBrandCount()
        {
            return await _client.GetFromJsonAsync<int>("Statistics/GetBrandCount");
        }
    }
}

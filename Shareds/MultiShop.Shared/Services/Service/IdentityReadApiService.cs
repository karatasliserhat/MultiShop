using MultiShop.DtoLayer;
using MultiShop.Shared.Services.Abstract;
using System.Net.Http.Json;

namespace MultiShop.Shared.Services.Service
{
    public class IdentityReadApiService : IIdentityReadApiService
    {
        private readonly HttpClient _client;

        public IdentityReadApiService(HttpClient client)
        {
            _client = client;
        }

        public async Task<int> GetUserCount()
        {
            return await _client.GetFromJsonAsync<int>("Users/GetUserCount");
        }

        public async Task<List<ResultUserDto>> GetUserListAsync()
        {
            var result = await _client.GetFromJsonAsync<List<ResultUserDto>>("Users/GetUserAll");
            if (result is { Count: > 0 })
            {
                return result;
            }
            return null;
        }
    }
}

using MultiShop.DtoLayer;
using MultiShop.Shared.Services.Abstract;
using System.Net.Http.Json;

namespace MultiShop.Shared.Services.Service
{
    public class IdentityCommandApiService : IIdentityCommandApiService
    {
        private readonly HttpClient _client;

        public IdentityCommandApiService(HttpClient client)
        {
            _client = client;
        }

        public async Task<HttpResponseMessage> RegisterUserAsync(RegisterDto registerDto)
        {
            var result = await _client.PostAsJsonAsync("Registers", registerDto);
            return result;
        }
    }
}

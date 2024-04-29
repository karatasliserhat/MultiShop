using MultiShop.DtoLayer;
using MultiShop.Shared.Services.Abstract;
using System.Net.Http.Json;
using System.Text.Json;

namespace MultiShop.Shared.Services.Service
{
    public class IdentityCommandApiService : IIdentityCommandApiService
    {
        private readonly HttpClient _client;

        public IdentityCommandApiService(HttpClient client)
        {
            _client = client;
        }

        public async Task<JwtResponseDto> LoginAsync(UserLoginDto userLoginDto)
        {
            var response = await _client.PostAsJsonAsync<UserLoginDto>("Logins", userLoginDto);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var tokenModel = JsonSerializer.Deserialize<JwtResponseDto>(jsonData, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                return tokenModel;
            }
            return new JwtResponseDto();
        }

        public async Task<HttpResponseMessage> RegisterUserAsync(RegisterDto registerDto)
        {
            var result = await _client.PostAsJsonAsync("Registers", registerDto);
            return result;
        }
    }
}

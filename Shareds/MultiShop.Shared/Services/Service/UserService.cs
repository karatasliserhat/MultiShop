using MultiShop.DtoLayer;
using MultiShop.Shared.Services.Abstract;
using System.Net.Http.Json;

namespace MultiShop.Shared.Services.Service
{
    public class UserService : IUserService
    {
        private readonly HttpClient _client;

        public UserService(HttpClient client)
        {
            _client = client;
        }

        public async Task<UserDetailDto> GetUserInfo()
        {
            return await _client.GetFromJsonAsync<UserDetailDto>("users/getuserinfo");
        }
    }
}

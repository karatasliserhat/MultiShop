using Microsoft.AspNetCore.Http;
using MultiShop.Shared.Services.Abstract;
using System.Net.Http.Headers;

namespace MultiShop.Shared.Services.Service
{
    public class AuthorizationTokenApiService : IAuthorizationTokenApiService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public AuthorizationTokenApiService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string AccessToken => _contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "accessToken")?.Value;

        public void TokenHeaderAuthorization(HttpClient client, string Token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
        }
    }
}

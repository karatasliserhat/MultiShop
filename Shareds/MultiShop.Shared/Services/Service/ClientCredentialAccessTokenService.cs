using MultiShop.DtoLayer;
using MultiShop.Shared.Services.Abstract;
using MultiShop.Shared.Settings;
using System.Text.Json.Nodes;

namespace MultiShop.Shared.Services.Service
{
    public class ClientCredentialAccessTokenService : IClientCredentialAccessTokenService
    {
        private readonly HttpClient _httpClient;
        private readonly IClientSettings _clientSettings;

        public ClientCredentialAccessTokenService(HttpClient httpClient, IClientSettings clientSettings)
        {
            _httpClient = httpClient;
            _clientSettings = clientSettings;
        }

        public async Task<AccessTokenDto> GetClientCredenditalAccessToken()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(_clientSettings.TokenUrl),
                Content = new FormUrlEncodedContent(new Dictionary<string, string>()
                {
                    {"client_id",_clientSettings.MultiShopVisitorClient.ClientId },
                    {"client_secret",_clientSettings.MultiShopVisitorClient.ClientSecret },
                    {"grant_type",_clientSettings.MultiShopVisitorClient.GrantType }
                })


            };
            var response = await _httpClient.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            var token = JsonObject.Parse(content);

            return new AccessTokenDto { AccessToken = token["access_token"].ToString() };
        }
    }
}

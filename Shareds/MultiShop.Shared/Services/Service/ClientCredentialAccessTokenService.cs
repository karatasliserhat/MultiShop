using IdentityModel.AspNetCore.AccessTokenManagement;
using IdentityModel.Client;
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
        private readonly IClientAccessTokenCache _cachingAccessTokenCache;
        public ClientCredentialAccessTokenService(HttpClient httpClient, IClientSettings clientSettings, IClientAccessTokenCache cachingAccessTokenCache)
        {
            _httpClient = httpClient;
            _clientSettings = clientSettings;
            _cachingAccessTokenCache = cachingAccessTokenCache;
        }

        public async Task<AccessTokenDto> GetClientCredenditalAccessToken()
        {
            var token1 = await _cachingAccessTokenCache.GetAsync("multishopaccesstoken");
            if (token1 is not null)
            {
                return new AccessTokenDto { AccessToken = token1.AccessToken };
            }

            var discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest { 
            
                Address=_clientSettings.DiscoveryUrl,
                Policy= new DiscoveryPolicy
                {
                    RequireHttps=false
                }
            
            });

            var clientCredentialTokenRequest = new ClientCredentialsTokenRequest
            {
                ClientId = _clientSettings.MultiShopVisitorClient.ClientId,
                ClientSecret = _clientSettings.MultiShopVisitorClient.ClientSecret,
                Address = discoveryEndPoint.TokenEndpoint
            };

            var token2 = await _httpClient.RequestClientCredentialsTokenAsync(clientCredentialTokenRequest);
            await _cachingAccessTokenCache.SetAsync("multishopaccesstoken", token2.AccessToken, token2.ExpiresIn);

            return new AccessTokenDto { AccessToken= token2.AccessToken };
        }
    }
}

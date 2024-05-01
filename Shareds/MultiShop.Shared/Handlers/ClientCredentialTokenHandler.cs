using MultiShop.Shared.Services.Abstract;
using System.Net;
using System.Net.Http.Headers;

namespace MultiShop.Shared.Handlers
{
    public class ClientCredentialTokenHandler : DelegatingHandler
    {
        private readonly IClientCredentialAccessTokenService _clientCredentialAccessTokenService;

        public ClientCredentialTokenHandler(IClientCredentialAccessTokenService clientCredentialAccessTokenService)
        {
            _clientCredentialAccessTokenService = clientCredentialAccessTokenService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await _clientCredentialAccessTokenService.GetClientCredenditalAccessToken();
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
            var response = await base.SendAsync(request, cancellationToken);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                //Hata Message
            }
            return response;
        }
    }
}

using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using MultiShop.DtoLayer;
using MultiShop.Shared.Services.Abstract;
using MultiShop.Shared.Settings;
using System.Security.Claims;

namespace MultiShop.Shared.Services.Service
{
    public class IdentitySignInService : IIdentitySignInService
    {
        private readonly HttpClient _client;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IClientSettings _clientSettings;
        public IdentitySignInService(HttpClient client, IHttpContextAccessor contextAccessor, IClientSettings clientSettings)
        {
            _client = client;
            _contextAccessor = contextAccessor;
            _clientSettings = clientSettings;
        }

        public async Task<bool> GetRefreshToken()
        {
            var discoveryEntdPoint = await _client.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {

                Address = _clientSettings.DiscoveryUrl,
                Policy = new DiscoveryPolicy
                {
                    RequireHttps = false
                }

            });
            var refreshToken = await _contextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.RefreshToken);
            var refreshTokenRequest = new RefreshTokenRequest
            {
                ClientId = _clientSettings.MultiShopManagerClient.ClientId,
                ClientSecret = _clientSettings.MultiShopManagerClient.ClientSecret,
                RefreshToken = refreshToken,
                Address = discoveryEntdPoint.TokenEndpoint
            };

            var token = await _client.RequestRefreshTokenAsync(refreshTokenRequest);

            var authenticationToken = new List<AuthenticationToken>() {

                new AuthenticationToken{
                    Name=OpenIdConnectParameterNames.AccessToken,
                    Value=token.AccessToken
                },

                new AuthenticationToken
                {
                     Name=OpenIdConnectParameterNames.RefreshToken,
                     Value=token.RefreshToken
                },
                new AuthenticationToken
                {
                    Name=OpenIdConnectParameterNames.ExpiresIn,
                    Value=DateTime.Now.AddDays(token.ExpiresIn).ToString()
                }

            };

            var result = await _contextAccessor.HttpContext.AuthenticateAsync();
            var properties = result.Properties;
            properties.StoreTokens(authenticationToken);

            await _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, result.Principal, properties);

            return true;
        }

        public async Task<bool> SignInAsync(SignInDto signInDto)
        {
            var discoveryEndPoint = await _client.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {

                Address = _clientSettings.DiscoveryUrl,
                Policy = new DiscoveryPolicy
                {
                    RequireHttps = false
                }

            });

            var passwordTokenRequest = new PasswordTokenRequest()
            {
                ClientId = _clientSettings.MultiShopManagerClient.ClientId,
                ClientSecret = _clientSettings.MultiShopManagerClient.ClientSecret,
                UserName = signInDto.UserName,
                Password = signInDto.Password,
                Address = discoveryEndPoint.TokenEndpoint
            };

            var token = await _client.RequestPasswordTokenAsync(passwordTokenRequest);

            var userEndPoint = new UserInfoRequest()
            {
                Token = token.AccessToken,
                Address = discoveryEndPoint.UserInfoEndpoint
            };

            var userValues = await _client.GetUserInfoAsync(userEndPoint);

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(userValues.Claims, CookieAuthenticationDefaults.AuthenticationScheme, "name", "role");
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            var authenticationProperties = new AuthenticationProperties();
            authenticationProperties.StoreTokens(new List<AuthenticationToken>() {


                new AuthenticationToken
                {
                    Name=OpenIdConnectParameterNames.AccessToken,
                    Value=token.AccessToken
                },
                new AuthenticationToken
                {
                    Name=OpenIdConnectParameterNames.RefreshToken,
                    Value=token.RefreshToken
                },
                new AuthenticationToken
                {
                    Name=OpenIdConnectParameterNames.ExpiresIn,
                    Value=DateTime.Now.AddDays(token.ExpiresIn).ToString()
                }


            });
            await _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authenticationProperties);

            return true;
        }

    }
}

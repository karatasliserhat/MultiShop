namespace MultiShop.Shared.Services.Abstract
{
    public interface IAuthorizationTokenApiService
    {
        public string AccessToken { get; }
        public void TokenHeaderAuthorization(HttpClient client, string Token);
    }
}

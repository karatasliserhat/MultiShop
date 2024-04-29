using MultiShop.DtoLayer;

namespace MultiShop.Shared.Services.Abstract
{
    public interface IClientCredentialAccessTokenService
    {
        Task<AccessTokenDto> GetClientCredenditalAccessToken();
    }
}

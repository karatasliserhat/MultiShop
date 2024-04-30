using MultiShop.DtoLayer;

namespace MultiShop.Shared.Services.Abstract
{
    public interface IIdentitySignInService
    {
        Task<bool> SignInAsync(SignInDto signInDto);
        Task<bool> GetRefreshToken();
    }
}

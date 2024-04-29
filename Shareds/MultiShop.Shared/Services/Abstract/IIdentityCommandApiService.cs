using MultiShop.DtoLayer;

namespace MultiShop.Shared.Services.Abstract
{
    public interface IIdentityCommandApiService
    {
        Task<HttpResponseMessage> RegisterUserAsync(RegisterDto registerDto);
        Task<JwtResponseDto> LoginAsync(UserLoginDto  userLoginDto);
    }
}

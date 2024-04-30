using MultiShop.DtoLayer;

namespace MultiShop.Shared.Services.Abstract
{
    public interface IUserService
    {
        Task<UserDetailDto> GetUserInfo();
    }
}

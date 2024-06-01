using MultiShop.DtoLayer;

namespace MultiShop.Shared.Services.Abstract
{
    public interface IIdentityReadApiService
    {
        Task<List<ResultUserDto>> GetUserListAsync();
        Task<int> GetUserCount();
    }
}

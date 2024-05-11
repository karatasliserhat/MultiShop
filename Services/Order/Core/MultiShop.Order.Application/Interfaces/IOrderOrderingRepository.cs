using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Interfaces
{
    public interface IOrderOrderingRepository
    {
        Task<List<Ordering>> GetListOrderingByUserIdAsync(string userId);
    }
}

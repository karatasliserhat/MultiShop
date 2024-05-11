using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using MultiShop.Order.Persistence.Context;

namespace MultiShop.Order.Persistence.Repositories
{
    public class OrderOrderingRepository : IOrderOrderingRepository
    {
        private readonly OrderContext _orderContext;

        public OrderOrderingRepository(OrderContext orderContext)
        {
            _orderContext = orderContext;
        }

        public async Task<List<Ordering>> GetListOrderingByUserIdAsync(string userId)
        {
            return await _orderContext.Orderings.Where(x=> x.UserId== userId).AsNoTracking().ToListAsync();
        }
    }
}

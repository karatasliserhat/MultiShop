using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Persistence.Context
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {

        }

        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Address> Adddress { get; set; }
        public DbSet<Ordering> Orderings { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using MultiShop.Discount.Entities;

namespace MultiShop.Discount.Context
{
    public class DapperContext : DbContext
    {
        public DapperContext(DbContextOptions<DapperContext> options) : base(options)
        {

        }

        public DbSet<Coupon> Coupons { get; set; }

    }
}

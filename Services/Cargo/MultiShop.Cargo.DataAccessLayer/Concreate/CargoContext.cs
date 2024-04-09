using Microsoft.EntityFrameworkCore;
using MultiShop.Cargo.EntityLayer.Concreate;

namespace MultiShop.Cargo.DataAccessLayer.Concreate
{
    public class CargoContext:DbContext
    {
        public CargoContext(DbContextOptions<CargoContext> option):base(option)
        {
            
        }
        public DbSet<CargoDetail> CargoDetails { get; set; }
        public DbSet<CargoCompany> CargoCompanies { get; set; }
        public DbSet<CargoOperation> CargoOperations { get; set; }
        public DbSet<CargoCustomer> CargoCustomers { get; set; }
    }
}

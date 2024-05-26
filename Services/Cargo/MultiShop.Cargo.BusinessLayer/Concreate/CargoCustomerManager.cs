using Microsoft.EntityFrameworkCore;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Concreate;
using MultiShop.Cargo.EntityLayer.Concreate;

namespace MultiShop.Cargo.BusinessLayer.Concreate
{
    public class CargoCustomerManager : GenericManager<CargoCustomer>, ICargoCustomerService
    {
        private readonly CargoContext _context;
        public CargoCustomerManager(IGenericDal<CargoCustomer> genericDal, CargoContext context) : base(genericDal)
        {
            _context = context;
        }

        public async Task<CargoCustomer> GetCarCustomerWithUserIdAsync(string userId, CancellationToken cancellationToken)
        {
            return await _context.CargoCustomers.AsNoTracking().Where(x => x.UserId == userId).FirstOrDefaultAsync(cancellationToken);
        }
    }
}

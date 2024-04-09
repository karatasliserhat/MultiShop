using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concreate;

namespace MultiShop.Cargo.BusinessLayer.Concreate
{
    public class CargoCustomerManager : GenericManager<CargoCustomer>, ICargoCustomerService
    {
        public CargoCustomerManager(IGenericDal<CargoCustomer> genericDal) : base(genericDal)
        {

        }
    }
}

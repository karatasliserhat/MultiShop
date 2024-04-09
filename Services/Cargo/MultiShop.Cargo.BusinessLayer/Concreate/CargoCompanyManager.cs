using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concreate;

namespace MultiShop.Cargo.BusinessLayer.Concreate
{
    public class CargoCompanyManager : GenericManager<CargoCompany>, ICargoCompanyService
    {
        public CargoCompanyManager(IGenericDal<CargoCompany> genericDal) : base(genericDal)
        {
        }
    }
}

using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concreate;

namespace MultiShop.Cargo.BusinessLayer.Concreate
{
    public class CargoDetailManager : GenericManager<CargoDetail>, ICargoDetailService
    {
        public CargoDetailManager(IGenericDal<CargoDetail> genericDal) : base(genericDal)
        {
        }
    }
}

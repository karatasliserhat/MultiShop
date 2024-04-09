using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concreate;

namespace MultiShop.Cargo.BusinessLayer.Concreate
{
    public class CargoOperationManager : GenericManager<CargoOperation>, ICargoOperationService
    {
        public CargoOperationManager(IGenericDal<CargoOperation> genericDal) : base(genericDal)
        {
        }
    }
}

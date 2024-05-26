using MultiShop.Cargo.DtoLayer.Dtos;
using MultiShop.Cargo.EntityLayer.Concreate;

namespace MultiShop.Cargo.BusinessLayer.Abstract
{
    public interface ICargoCustomerService : IGenericService<CargoCustomer>
    {
        Task<CargoCustomer> GetCarCustomerWithUserIdAsync(string userId, CancellationToken cancellationToken);
    }
}

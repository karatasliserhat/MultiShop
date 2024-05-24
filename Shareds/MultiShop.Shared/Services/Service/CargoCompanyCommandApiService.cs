using MultiShop.DtoLayer.CargoDtos;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.Shared.Services.Service
{
    public class CargoCompanyCommandApiService : ApiCommandService<UpdateCargoCompanyDto, CreateCargoCompanyDto>, ICargoCompanyCommandApiService
    {
        public CargoCompanyCommandApiService(HttpClient client) : base(client)
        {
        }
    }
}

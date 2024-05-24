using MultiShop.DtoLayer.CargoDtos;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.Shared.Services.Service
{
    public class CargoCompanyReadApiService : ApiReadService<ResultCargoCompanyDto>, ICargoCompanyReadApiService
    {
        public CargoCompanyReadApiService(HttpClient client) : base(client)
        {
        }
    }
}

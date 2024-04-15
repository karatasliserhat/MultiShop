using MultiShop.DtoLayer.CatalogDtos;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.Shared.Services.Service
{
    public class SpecialOfferCommandApiService : ApiCommandService<UpdateSpecialOfferDto, CreateSpecialOfferDto>, ISpecialOfferCommandApiService
    {
        public SpecialOfferCommandApiService(HttpClient client) : base(client)
        {
        }
    }
}

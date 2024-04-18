using MultiShop.DtoLayer.CatalogDtos;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.Shared.Services.Service
{
    public class OfferDiscountCommandApiService : ApiCommandService<UpdateOfferDiscountDto, CreateOfferDiscountDto>, IOfferDiscountCommandApiService
    {
        public OfferDiscountCommandApiService(HttpClient client) : base(client)
        {
        }
    }
}

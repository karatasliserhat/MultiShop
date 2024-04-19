using MultiShop.DtoLayer.CatalogDtos;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.Shared.Services.Service
{
    public class AboutCommandApiService : ApiCommandService<UpdateAboutDto, CreateAboutDto>, IAboutCommandApiService
    {
        public AboutCommandApiService(HttpClient client) : base(client)
        {
        }
    }
}

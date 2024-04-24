using MultiShop.DtoLayer.CatalogDtos;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.Shared.Services.Service
{
    public class ContactCommandApiService : ApiCommandService<UpdateContactDto, CreateContactDto>, IContactCommandApiService
    {
        public ContactCommandApiService(HttpClient client) : base(client)
        {
        }
    }
}

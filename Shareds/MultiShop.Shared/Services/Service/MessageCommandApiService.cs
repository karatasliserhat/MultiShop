using MultiShop.DtoLayer;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.Shared.Services.Service
{
    public class MessageCommandApiService : ApiCommandService<UpdateMessageDto, CreateMessageDto>, IMessageCommandApiService
    {
        public MessageCommandApiService(HttpClient client) : base(client)
        {
        }
    }
}

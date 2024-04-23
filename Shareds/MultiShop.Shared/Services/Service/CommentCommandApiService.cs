using MultiShop.DtoLayer.CommentDtos;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.Shared.Services.Service
{
    public class CommentCommandApiService : ApiCommandService<UpdateCommentDto, CreateCommentDto>, ICommentCommandApiService
    {
        public CommentCommandApiService(HttpClient client) : base(client)
        {
        }
    }
}

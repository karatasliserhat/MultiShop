using MultiShop.DtoLayer.CommentDtos;

namespace MultiShop.Shared.Services.Abstract
{
    public interface ICommentReadApiService:IApiReadService<ResultCommentDto>
    {
        Task<List<ResultCommentDto>> GetCommentByProductIdAsync(string productId);
    }
}

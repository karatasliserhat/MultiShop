using MultiShop.DtoLayer.CommentDtos;

namespace MultiShop.Shared.Services.Abstract
{
    public interface ICommentReadApiService:IApiReadService<ResultCommentDto>
    {
        Task<List<ResultCommentDto>> GetCommentByProductIdAsync(string productId);
        Task<int> GetActiveCommentCount();
        Task<int> GetPassiveCommentCount();
        Task<int> GetTotalCommentCount();
    }
}

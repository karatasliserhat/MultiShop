using MultiShop.DtoLayer;

namespace MultiShop.Shared.Services.Abstract
{
    public interface IMessageReadApiService:IApiReadService<ResultMessageDto>
    {
        Task<List<ResultSendboxMessageDto>> SendBoxMessageAsync(string UserId);
        Task<List<ResultInboxMessageDto>> InBoxMessageAsync(string UserId);
        Task IsReadMessage(int MessageId);
        Task<int> GetMessageCount();
    }
}

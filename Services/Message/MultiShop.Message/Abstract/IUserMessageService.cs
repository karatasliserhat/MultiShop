using MultiShop.Message.Dtos;

namespace MultiShop.Message.Abstract
{
    public interface IUserMessageService
    {
        Task<List<ResultMessageDto>> MessageAllAsync();
        Task<List<ResultInboxMessageDto>> MessageInboxAsync(string ReceiverUserId);
        Task<List<ResultSendboxMessageDto>> MessageSendboxAsync(string SenderUserId);
        Task CreateMessageAsync(CreateMessageDto createMessageDto);
        Task UpdateMessageAsync(UpdateMessageDto updateMessageDto);
        Task<GetByIdMessageAsync> GetByIdMessageAsync(int messageId);
        Task<bool> IsReadMessageAsync(int messageId);
        Task DeleteAsync(int messageId);
    }
}

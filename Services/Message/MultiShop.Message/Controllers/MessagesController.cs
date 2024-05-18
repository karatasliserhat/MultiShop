using Microsoft.AspNetCore.Mvc;
using MultiShop.Message.Abstract;
using MultiShop.Message.Dtos;

namespace MultiShop.Message.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IUserMessageService _messageService;

        public MessagesController(IUserMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMessage()
        {
            return Ok(await _messageService.MessageAllAsync());
        }
        [HttpGet("[Action]/{MessageId}")]
        public async Task<IActionResult> GetMessage(int MessageId)
        {
            return Ok(await _messageService.GetByIdMessageAsync(MessageId));
        }
        [HttpGet("[Action]/{ReceiverId}")]
        public async Task<IActionResult> GetReceiverAllMessage(string ReceiverId)
        {
            return Ok(await _messageService.MessageInboxAsync(ReceiverId));
        }
        [HttpGet("[Action]/{MessageId}")]
        public async Task<IActionResult> IsReadMessage(int MessageId)
        {
            var values = await _messageService.IsReadMessageAsync(MessageId);
            if (values)
            {
                return Ok("Mesaj Okundu");
            }
            return Ok("Mesaj Okunurken bir hata alındı");
        }
        [HttpGet("[Action]/{SenderId}")]
        public async Task<IActionResult> GetSenderAllMessage(string SenderId)
        {
            return Ok(await _messageService.MessageSendboxAsync(SenderId));
        }
        [HttpPost]
        public async Task<IActionResult> CreateMessage(CreateMessageDto createMessageDto)
        {
            await _messageService.CreateMessageAsync(createMessageDto);
            return Ok("Mesaj Gönderildi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            await _messageService.UpdateMessageAsync(updateMessageDto);
            return Ok("Mesaj Güncellendi");
        }
        [HttpDelete("{messageId}")]
        public async Task<IActionResult> DeleteMessage(int messageId)
        {
            await _messageService.DeleteAsync(messageId);
            return Ok("Mesaj Silindi");
        }
    }
}

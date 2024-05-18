using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultiShop.Message.Abstract;
using MultiShop.Message.DAL.Context;
using MultiShop.Message.DAL.Entities;
using MultiShop.Message.Dtos;

namespace MultiShop.Message.Services
{
    public class UserMessageService : IUserMessageService
    {
        private readonly MessageContext _context;
        private readonly IMapper _mapper;
        public UserMessageService(MessageContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateMessageAsync(CreateMessageDto createMessageDto)
        {
            createMessageDto.IsRead = false;
            await _context.UserMessages.AddAsync(_mapper.Map<UserMessage>(createMessageDto));
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int messageId)
        {
             _context.UserMessages.Remove(_context.UserMessages.Find(messageId));
            await _context.SaveChangesAsync();
        }

        public async Task<GetByIdMessageAsync> GetByIdMessageAsync(int messageId)
        {
            return _mapper.Map<GetByIdMessageAsync>(await _context.UserMessages.FirstOrDefaultAsync(x => x.UserMessageId == messageId));
        }

        public async Task<bool> IsReadMessageAsync(int messageId)
        {
            await _context.UserMessages.Where(x => x.UserMessageId == messageId).ExecuteUpdateAsync(x => x.SetProperty(x => x.IsRead, true));
            return true;

        }

        public async Task<List<ResultMessageDto>> MessageAllAsync()
        {
            return _mapper.Map<List<ResultMessageDto>>(await _context.UserMessages.AsNoTracking().ToListAsync());
        }

        public async Task<List<ResultInboxMessageDto>> MessageInboxAsync(string ReceiverUserId)
        {
            return _mapper.Map<List<ResultInboxMessageDto>>(await _context.UserMessages.Where(x => x.ReceiverId == ReceiverUserId).ToListAsync());
        }

        public async Task<List<ResultSendboxMessageDto>> MessageSendboxAsync(string SenderUserId)
        {
            return _mapper.Map<List<ResultSendboxMessageDto>>(await _context.UserMessages.Where(x => x.SenderId == SenderUserId).ToListAsync());
        }

        public async Task UpdateMessageAsync(UpdateMessageDto updateMessageDto)
        {
            _context.UserMessages.Update(_mapper.Map<UserMessage>(updateMessageDto));
            await _context.SaveChangesAsync();
        }
    }
}

using Microsoft.AspNetCore.SignalR;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.WebUI.SignalRHub
{
    public class MyHub : Hub
    {
        private readonly ICommentReadApiService _commentReadApiService;
        private readonly IMessageReadApiService _messageReadApiServiece;
        private readonly IGetUserService _userService;

        public MyHub(ICommentReadApiService commentReadApiService, IMessageReadApiService messageReadApiServiece, IGetUserService userService)
        {
            _commentReadApiService = commentReadApiService;
            _messageReadApiServiece = messageReadApiServiece;
            _userService = userService;
        }

        public async Task SendStatistic()
        {
            var commentCount = await _commentReadApiService.GetTotalCommentCount();
            await Clients.All.SendAsync("ReceiveCommentCount", commentCount);


            var inboxMessageCount = await _messageReadApiServiece.InBoxMessageAsync(_userService.GetUserId);
            await Clients.All.SendAsync("ReceiveInboxMessageCount", inboxMessageCount.Count);
        }
    }
}

using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    [Route("User/[Controller]/[Action]")]
    public class MessageController : Controller
    {
        private readonly IMessageReadApiService _messageReadApiService;
        private readonly IMessageCommandApiService _messageCommandApiService;
        private readonly IDataProtector _dataProtector;
        private readonly IGetUserService _userService;
        public MessageController(IMessageReadApiService messageReadApiService, IDataProtectionProvider dataProtector, IMessageCommandApiService messageCommandApiService, IGetUserService userService)
        {
            _messageReadApiService = messageReadApiService;
            _dataProtector = dataProtector.CreateProtector("UserMessageController");
            _messageCommandApiService = messageCommandApiService;
            _userService = userService;
        }

        public async Task<IActionResult> InBoxMessage()
        {
            var values = await _messageReadApiService.InBoxMessageAsync(_userService.GetUserId);
            values.ForEach(x => x.DataProtect = _dataProtector.Protect(x.UserMessageId.ToString()));
            return View(values);
        }
        public async Task<IActionResult> SenderBoxMessage()
        {
            var values = await _messageReadApiService.SendBoxMessageAsync(_userService.GetUserId);
            values.ForEach(x => x.DataProtect = _dataProtector.Protect(x.UserMessageId.ToString()));
            return View(values);
        }
        public async Task<IActionResult> DeleteMessage(string messageId)
        {

            await _messageCommandApiService.RemoveAsync("messages", int.Parse(_dataProtector.Unprotect(messageId)));
            return RedirectToAction(nameof(InBoxMessage));
        }
        public async Task<IActionResult> ReadMessage(string messageId)
        {
            await _messageReadApiService.IsReadMessage(int.Parse(_dataProtector.Unprotect(messageId)));
            return RedirectToAction(nameof(InBoxMessage));
        }
    }
}

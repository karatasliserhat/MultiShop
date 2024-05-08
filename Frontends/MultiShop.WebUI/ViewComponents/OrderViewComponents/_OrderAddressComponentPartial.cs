using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.OrderDtos;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.WebUI.ViewComponents.OrderViewComponents
{
    public class _OrderAddressComponentPartial : ViewComponent
    {
        private readonly IUserService _userService;

        public _OrderAddressComponentPartial(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var valuesUser = await _userService.GetUserInfo();
            return View(new CreateAddressDto { UserId = valuesUser.Id });
        }
    }
}

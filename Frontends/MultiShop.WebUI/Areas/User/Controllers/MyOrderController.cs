using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Shared.Enums;
using MultiShop.Shared.Services.Abstract;
using MultiShop.WebUI.Areas.User.Models;
using System.Drawing;

namespace MultiShop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    [Route("User/[Controller]/[Action]")]
    public class MyOrderController : Controller
    {
        private readonly IOrderingReadApiService _orderingReadApiService;
        private readonly IGetUserService _userService;
        private readonly IDataProtector _dataProtector;
        public MyOrderController(IOrderingReadApiService orderingReadApiService, IGetUserService userService, IDataProtectionProvider dataProtector)
        {
            _orderingReadApiService = orderingReadApiService;
            _userService = userService;
            _dataProtector = dataProtector.CreateProtector("MyOrderController");
        }

        public async Task<IActionResult> Index()
        {
            var values = await _orderingReadApiService.GetAllOrderingByUserId(_userService.GetUserId);
            if (values is not null)
            {
                values.ForEach(x => x.DataProtect = _dataProtector.Protect(x.OrderingId.ToString()));
                int z = 0;
                for (int i = 0; i < values.Count; i++)
                {
                    int y = 1;
                    do
                    {
                        values[i].TableRowColor = TableColorList.Colors[z];
                        y++;
                        z++;
                    } while (y < 1);
                    if (z == TableColorList.Colors.Count)
                    {
                        z = 0;
                    }
                }
                return View(values);
            }
            return View(null);
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.OrderViewComponents
{
    public class _OrderShoppingDetailComponentPartial:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}

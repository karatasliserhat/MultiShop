using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.OrderViewComponents
{
    public class _OrderPaymentComponentPartial:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}

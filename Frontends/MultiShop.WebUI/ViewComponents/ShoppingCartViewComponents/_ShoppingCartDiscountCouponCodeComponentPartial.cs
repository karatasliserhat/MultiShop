using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.WebUI.ViewComponents.ShoppingCartViewComponents
{
    public class _ShoppingCartDiscountCouponCodeComponentPartial:ViewComponent
    {
       
        public IViewComponentResult Invoke()
        {
            return View(new GetDiscountCodeDto());
        }
    }
}

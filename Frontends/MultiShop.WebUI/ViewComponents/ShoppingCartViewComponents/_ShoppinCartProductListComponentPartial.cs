using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.WebUI.ViewComponents.ShoppingCartViewComponents
{
    public class _ShoppinCartProductListComponentPartial : ViewComponent
    {
        private readonly IBasketReadApiService _basketReadApiService;
        private readonly IDataProtector _basketDataProtector;

        public _ShoppinCartProductListComponentPartial(IBasketReadApiService basketReadApiService, IDataProtectionProvider basketDataProtector)
        {
            _basketReadApiService = basketReadApiService;
            _basketDataProtector = basketDataProtector.CreateProtector("ShoppingCartController");

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _basketReadApiService.GetBasketAsync();
            values.BasketItems.ForEach(x => x.DataProtect = _basketDataProtector.Protect(x.ProductId));
            return View(values);
        }
    }
}

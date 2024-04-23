using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ReviewProductDetailComponenetPartial : ViewComponent
    {
        private readonly IDataProtector _dataProtector;
        private readonly ICommentReadApiService _commentReadApiService;
        public _ReviewProductDetailComponenetPartial(IDataProtectionProvider dataProtector, ICommentReadApiService commentReadApiService)
        {
            _dataProtector = dataProtector.CreateProtector("FeatureProductDefaultViewComponent");
            _commentReadApiService = commentReadApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await _commentReadApiService.GetCommentByProductIdAsync(_dataProtector.Unprotect(id));
            if (values.Count>0)
            {
                return View(values);
            }
            return View();
        }
    }
}

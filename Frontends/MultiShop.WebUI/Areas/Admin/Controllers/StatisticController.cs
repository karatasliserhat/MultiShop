using Microsoft.AspNetCore.Mvc;
using MultiShop.Shared.Services.Abstract;
using System.Globalization;
using System.Text.RegularExpressions;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]")]
    public class StatisticController : Controller
    {
        private readonly ICategoryReadApiService _categoryReadApiService;
        private readonly IProductReadApiService _productReadApiService;
        private readonly IIdentityReadApiService _identityReadApiService;
        private readonly IBrandReadApiService _brandReadApiService;
        private readonly IDiscountReadApiService _discountReadApiService;
        private readonly ICommentReadApiService _commentReadApiService;
        private readonly IMessageReadApiService _messagereReadApiService;
        public StatisticController(ICategoryReadApiService categoryReadApiService, IProductReadApiService productReadApiService, IIdentityReadApiService identityReadApiService, IBrandReadApiService brandReadApiService, IDiscountReadApiService discountReadApiService, ICommentReadApiService commentReadApiService, IMessageReadApiService messagereReadApiService)
        {
            _categoryReadApiService = categoryReadApiService;
            _productReadApiService = productReadApiService;
            _identityReadApiService = identityReadApiService;
            _brandReadApiService = brandReadApiService;
            _discountReadApiService = discountReadApiService;
            _commentReadApiService = commentReadApiService;
            _messagereReadApiService = messagereReadApiService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "İstatistik İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "İstitistikler";
            ViewBag.v3 = "İstatistik Sayfası";


            var specifier = "N";
            var culture = CultureInfo.CreateSpecificCulture("es-ES");
            var avg = await _productReadApiService.GetProductAvgPrice();

            ViewBag.CategoryCount = await _categoryReadApiService.GetCategoryCount();
            ViewBag.ProductCount = await _productReadApiService.GetProductCount();
            ViewBag.MaxProductName = await _productReadApiService.GetMaxPriceProductName();
            ViewBag.MinProductName = await _productReadApiService.GetMinPriceProductName();
            ViewBag.AvgProductPrice = avg.ToString(specifier, culture);
            ViewBag.BrandCount = await _brandReadApiService.GetBrandCount();
            ViewBag.CommentPassiveCount = await _commentReadApiService.GetPassiveCommentCount();
            ViewBag.CommentActiveCount = await _commentReadApiService.GetActiveCommentCount();
            ViewBag.CommentTotalCount = await _commentReadApiService.GetTotalCommentCount();
            ViewBag.UserCount = await _identityReadApiService.GetUserCount();
            ViewBag.DiscountCount = await _discountReadApiService.GetDiscountCount();
            ViewBag.MessageCount = await _messagereReadApiService.GetMessageCount();
            return View();
        }
    }
}

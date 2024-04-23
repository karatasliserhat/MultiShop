using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentDtos;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        private readonly IDataProtector _dataProtector;
        private readonly ICommentCommandApiService _commentCommandApiService;
        public ProductListController(IDataProtectionProvider dataProtector, ICommentCommandApiService commentCommandApiService)
        {
            _dataProtector = dataProtector.CreateProtector("FeatureProductDefaultViewComponent");
            _commentCommandApiService = commentCommandApiService;
        }

        public IActionResult Index(string id)
        {
            ViewBag.dataId = id;
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v3 = "Ürünler";
            ViewBag.v2 = "Ürün Listesi";
            return View();
        }

        public IActionResult ProductDetail(string id)
        {
            ViewBag.dataId = id;

            //Comment Yorum yapma partial Viewa Gönderildi.
            TempData["productId"] = id;

            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v3 = "Ürün Listesi";
            ViewBag.v2 = "Ürün Detayları";
            return View();
        }

        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> AddComment(CreateCommentDto createCommentDto)
        {
            createCommentDto.ImageUrl = "/Images/NoImages/nofoto.jpg";
            createCommentDto.ProductId = _dataProtector.Unprotect(createCommentDto.ProductId);
            var result = await _commentCommandApiService.CreateAsync("Comments", createCommentDto);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(ProductDetail), new { id = _dataProtector.Protect(createCommentDto.ProductId) });
            }
            return View(createCommentDto);
        }
    }
}

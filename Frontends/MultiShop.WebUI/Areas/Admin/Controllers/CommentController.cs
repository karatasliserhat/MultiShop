using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CommentDtos;
using MultiShop.Shared.Enums;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]")]
    public class CommentController : Controller
    {
        private readonly ICommentCommandApiService _commentCommandApiService;
        private readonly ICommentReadApiService _commentReadApiService;
        private readonly IProductReadApiService _productReadApiService;
        private readonly IDataProtector _dataprotector;
        private readonly IMapper _mapper;

        public CommentController(ICommentCommandApiService commentCommandApiService, ICommentReadApiService commentReadApiService, IProductReadApiService productReadApiService, IDataProtectionProvider dataprotector, IMapper mapper)
        {
            _commentCommandApiService = commentCommandApiService;
            _commentReadApiService = commentReadApiService;
            _productReadApiService = productReadApiService;
            _dataprotector = dataprotector.CreateProtector("AdminCommentController");
            _mapper = mapper;
        }

        public void SelectTrueFalse()
        {
            ViewBag.SelectTrueFalse = new SelectList(Enum.GetValues(typeof(TrueFalse)));
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "Yorum İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Yorumlar";
            ViewBag.v3 = "Yorumlar Listesi";

            var result = await _commentReadApiService.GetListAsync("Comments");
            if (result.Any())
            {

                foreach (var item in result)
                {
                    var productData = await _productReadApiService.GetByIdAsync("Products", item.ProductId);
                    item.DataProtect = _dataprotector.Protect(item.UserCommentId.ToString());
                    item.ProductName = productData.Name;

                }
                return View(result);
            }
            return View();
        }
        public async Task<IActionResult> Update(string id)
        {
            ViewBag.v0 = "Yorum İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Yorumlar";
            ViewBag.v3 = "Yorum Güncelleme";
            var result = _mapper.Map<UpdateCommentDto>(await _commentReadApiService.GetByIdAsync("Comments", int.Parse(_dataprotector.Unprotect(id))));
            if (result is not null)
            {
                SelectTrueFalse();
                return View(result);
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateCommentDto updateCommentDto)
        {
            var result = await _commentCommandApiService.UpdateAsync("Comments", updateCommentDto);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            SelectTrueFalse();
            return View();
        }
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _commentCommandApiService.RemoveAsync("Comments", int.Parse(_dataprotector.Unprotect(id)));
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}

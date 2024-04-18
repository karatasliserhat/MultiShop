using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]")]
    public class OfferDiscountController : Controller
    {
        private readonly IOfferDiscountCommandApiService _offerDiscountCommandApiService;
        private readonly IOfferDiscountReadApiService _offerDiscountReadApiService;
        private readonly IDataProtector _dataProtector;
        private readonly IMapper _mapper;

        public OfferDiscountController(IOfferDiscountCommandApiService offerDiscountCommandApiService, IOfferDiscountReadApiService offerDiscountReadApiService, IDataProtectionProvider dataProtector, IMapper mapper)
        {
            _offerDiscountCommandApiService = offerDiscountCommandApiService;
            _offerDiscountReadApiService = offerDiscountReadApiService;
            _dataProtector = dataProtector.CreateProtector("AdminOfferDiscountController");
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "İndirim Teklif İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "İndirim Teklifleri";
            ViewBag.v3 = "İndirim Teklifleri Listesi";
            var result = await _offerDiscountReadApiService.GetListAsync("OfferDiscounts");
            if (result is not null)
            {
                result.ForEach(x => x.DataProtect = _dataProtector.Protect(x.OfferDiscountId));
                return View(result);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateOfferDiscount()
        {
            ViewBag.v0 = "İndirim Teklif İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "İndirim Teklifleri";
            ViewBag.v3 = "Yeni İndirim Teklif Girişi";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
        {
            var result = await _offerDiscountCommandApiService.CreateAsync("OfferDiscounts", createOfferDiscountDto);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public async Task<IActionResult> Update(string id)
        {
            ViewBag.v0 = "İndirim Teklif İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "İndirim Teklifleri";
            ViewBag.v3 = "İndirim Teklif Güncelleme";
            var result = _mapper.Map<UpdateOfferDiscountDto>(await _offerDiscountReadApiService.GetByIdAsync("OfferDiscounts", _dataProtector.Unprotect(id)));
            if (result is not null)
            {
                return View(result);
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            var result = await _offerDiscountCommandApiService.UpdateAsync("OfferDiscounts", updateOfferDiscountDto);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _offerDiscountCommandApiService.RemoveAsync("OfferDiscounts", _dataProtector.Unprotect(id));
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}

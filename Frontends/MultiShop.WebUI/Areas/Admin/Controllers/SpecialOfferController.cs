using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos;
using MultiShop.Shared.Enums;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]")]
    public class SpecialOfferController : Controller
    {
        private readonly ISpecialOfferReadApiService _specialOfferReadApiService;
        private readonly ISpecialOfferCommandApiService _specialOfferCommandApiService;
        private readonly IMapper _mapper;
        private readonly IDataProtector _dataProtector;


        public SpecialOfferController(ISpecialOfferReadApiService specialOfferReadApiService, ISpecialOfferCommandApiService specialOfferCommandApiService, IMapper mapper, IDataProtectionProvider dataProtector)
        {
            _specialOfferReadApiService = specialOfferReadApiService;
            _specialOfferCommandApiService = specialOfferCommandApiService;
            _mapper = mapper;
            _dataProtector = dataProtector.CreateProtector("AdminSpecialOfferController");
        }
        public void SelectEnumTrueFalse()
        {
            ViewBag.SelectTrueFalse = new SelectList(Enum.GetValues(typeof(TrueFalse)));
        }
        public async Task<IActionResult> Index()
        {
            string token = "";

            var values = await _specialOfferReadApiService.GetListAsync("SpecialOffers", token);
            if (values.Count > 0)
            {
                values.ForEach(x => x.DataProtect = _dataProtector.Protect(x.SpecialOfferId));
                return View(values);

            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateSpecialOffer()
        {
            ViewBag.v0 = "Özel Teklif İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Özel Teklifler";
            ViewBag.v3 = "Özel Teklif Girişi";

            SelectEnumTrueFalse();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
        {
            var response = await _specialOfferCommandApiService.CreateAsync("SpecialOffers", createSpecialOfferDto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            SelectEnumTrueFalse();
            return View();
        }
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _specialOfferCommandApiService.RemoveAsync("SpecialOffers", _dataProtector.Unprotect(id));
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));

            }
            return View();
        }
        [HttpGet]
        public async Task< IActionResult> Update(string id)
        {
            ViewBag.v0 = "Özel Teklif İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Özel Teklifler";
            ViewBag.v3 = "Özel Teklif Değişimi";

            var response = _mapper.Map<UpdateSpecialOfferDto>(await _specialOfferReadApiService.GetByIdAsync("SpecialOffers", _dataProtector.Unprotect(id)));
            if (response is not null)
            {
                SelectEnumTrueFalse();
                return View(response);

            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            var response = await _specialOfferCommandApiService.UpdateAsync("SpecialOffers", updateSpecialOfferDto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            SelectEnumTrueFalse();
            return View();
        }


    }
}

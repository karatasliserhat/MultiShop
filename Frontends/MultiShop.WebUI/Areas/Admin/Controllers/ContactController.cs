using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]")]
    public class ContactController : Controller
    {
        private readonly IContactCommandApiService _contactCommandApiService;
        private readonly IContactReadApiService _contactReadApiService;
        private readonly IMapper _mapper;
        private readonly IDataProtector _dataProtector;

        public ContactController(IContactCommandApiService contactCommandApiService, IContactReadApiService contactReadApiService, IMapper mapper, IDataProtectionProvider dataProtector)
        {
            _contactCommandApiService = contactCommandApiService;
            _contactReadApiService = contactReadApiService;
            _mapper = mapper;
            _dataProtector = dataProtector.CreateProtector("AdminContactController");
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "İletişim İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "İletişim Mesajları";
            ViewBag.v3 = "İletişim Mesaj Listesi";

            var result = await _contactReadApiService.GetListAsync("Contacts");
            if (result.Count > 0)
            {
                result.ForEach(x => x.DataProtect = _dataProtector.Protect(x.ContactId.ToString()));
                return View(result);
            }
            return View();
        }
        //[HttpGet]
        //public IActionResult CreateContact()
        //{
        //    ViewBag.v0 = "İletişim İşlemleri";
        //    ViewBag.v1 = "Ana Sayfa";
        //    ViewBag.v2 = "İletişim Mesajları";
        //    ViewBag.v3 = "Yeni Kategori Girişi";
        //    return View();
        //}
        //[HttpPost]
        //public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
        //{
        //    var result = await _contactCommandApiService.CreateAsync("Contacts", createContactDto);
        //    if (result.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View();
        //}
        public async Task<IActionResult> Update(string id)
        {
            ViewBag.v0 = "İletişim İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "İletişim Mesajları";
            ViewBag.v3 = "Kategori Güncelleme";

            var result = _mapper.Map<UpdateContactDto>(await _contactReadApiService.GetByIdAsync("Contacts", _dataProtector.Unprotect(id)));
            if (result is not null)
            {
                return View(result);
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateContactDto updateContactDto)
        {
            var result = await _contactCommandApiService.UpdateAsync("Contacts", updateContactDto);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _contactCommandApiService.RemoveAsync("Contacts", _dataProtector.Unprotect(id));
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}

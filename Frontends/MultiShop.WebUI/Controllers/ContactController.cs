using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactCommandApiService _contactCommandApiService;

        public ContactController(IContactCommandApiService contactCommandApiService)
        {
            _contactCommandApiService = contactCommandApiService;
        }

        public IActionResult Index()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "İletişim";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
        {
            var result = await _contactCommandApiService.CreateAsync("Contacts",createContactDto);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}

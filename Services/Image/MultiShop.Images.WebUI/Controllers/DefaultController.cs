using Microsoft.AspNetCore.Mvc;
using MultiShop.Images.WebUI.Dal.Entities;
using MultiShop.Images.WebUI.Services;

namespace MultiShop.Images.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly ICloudStorageService _cloudStorageService;

        public DefaultController(ICloudStorageService cloudStorageService)
        {
            _cloudStorageService = cloudStorageService;
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ImageDrive imageDrive)
        {
            
                if (imageDrive is not null)
                {
                imageDrive.SavedFileName = GenerateFileNameToSave(imageDrive.Photo.FileName);
                imageDrive.SavedUrl = await _cloudStorageService.UploadFileAsync(imageDrive.Photo, imageDrive.SavedFileName);
                }
                return RedirectToAction("Default", "Index");
            
        }
        private string? GenerateFileNameToSave(string incomingFileName)
        {
            var fileName = Path.GetFileNameWithoutExtension(incomingFileName);
            var extension = Path.GetExtension(incomingFileName);
            return $"{fileName}-{DateTime.Now.ToUniversalTime().ToString("yyyyMMddHHmmss")}{extension}";
        }

    }
}

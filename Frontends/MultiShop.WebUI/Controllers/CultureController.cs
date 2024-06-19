﻿using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers
{
    public class CultureController : Controller
    {
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, 
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)), new CookieOptions{
                Expires = DateTimeOffset.UtcNow.AddYears(1),
            });
            return LocalRedirect(returnUrl);
        }
    }
}

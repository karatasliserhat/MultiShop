using Microsoft.AspNetCore.Http;
using MultiShop.Shared.Services.Abstract;
using System.Security.Claims;

namespace MultiShop.Shared.Services.Service
{
    public class LoginService : ILoginService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public LoginService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string GetUserId => _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    }
}

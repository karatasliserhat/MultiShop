using Microsoft.AspNetCore.Http;
using MultiShop.Shared.Services.Abstract;

namespace MultiShop.Shared.Services.Service
{
    public class GetUserService : IGetUserService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public GetUserService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string GetUserId => _contextAccessor.HttpContext.User.Claims.Where(x => x.Type == "sub").First()?.Value;
    }
}

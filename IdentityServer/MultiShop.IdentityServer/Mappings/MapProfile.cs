using AutoMapper;
using MultiShop.IdentityServer.Dtos;
using MultiShop.IdentityServer.Models;

namespace MultiShop.IdentityServer.Mappings
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<ApplicationUser, UserRegisterDto>().ReverseMap();
        }
    }
}

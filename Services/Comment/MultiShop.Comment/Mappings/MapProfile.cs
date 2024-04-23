using AutoMapper;
using MultiShop.Comment.Dtos;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Mappings
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<UserComment, CreateCommentDto>().ReverseMap();
            CreateMap<UserComment, ResultCommentDto>().ReverseMap();
            CreateMap<UserComment, GetByIdCommentDto>().ReverseMap();
            CreateMap<UserComment, UpdateCommentDto>().ReverseMap();
        }
    }
}

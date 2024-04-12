using AutoMapper;
using MultiShop.DtoLayer.CatalogDtos;

namespace MultiShop.WebUI.Mappings
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<ResultCategoryDto, UpdateCategoryDto>();
        }
    }
}

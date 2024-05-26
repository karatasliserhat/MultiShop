using AutoMapper;
using MultiShop.Cargo.DtoLayer.Dtos;
using MultiShop.Cargo.EntityLayer.Concreate;

namespace MultiShop.Cargo.BusinessLayer.Mappings
{
    public class MapProfile:Profile
    {
       public MapProfile()
        {
            CreateMap<CargoCompany, GetCargoCompanyDto>().ReverseMap();
            CreateMap<CargoCompany, CreateCargoCompanyDto>().ReverseMap();
            CreateMap<CargoCompany, UpdateCargoCompanyDto>().ReverseMap();
            CreateMap<CargoCompany, ResultCargoCompanyDto>().ReverseMap();

            CreateMap<CargoDetail, GetCargoDetailDto>().ReverseMap();
            CreateMap<CargoDetail, CreateCargoDetailDto>().ReverseMap();
            CreateMap<CargoDetail, UpdateCargoDetailDto>().ReverseMap();
            CreateMap<CargoDetail, ResultCargoDetailDto>().ReverseMap();

            CreateMap<CargoCustomer, GetCargoCustomerDto>().ReverseMap();
            CreateMap<CargoCustomer, CreateCargoCustomerDto>().ReverseMap();
            CreateMap<CargoCustomer, UpdateCargoCustomerDto>().ReverseMap();
            CreateMap<CargoCustomer, ResultCargoCustomerDto>().ReverseMap();
            CreateMap<CargoCustomer, GetCargoCustomerWithUserIdDto>().ReverseMap();

            CreateMap<CargoOperation, GetCargoOperationDto>().ReverseMap();
            CreateMap<CargoOperation, CreateCargoOperationDto>().ReverseMap();
            CreateMap<CargoOperation, UpdateCargoOperationDto>().ReverseMap();
            CreateMap<CargoOperation, ResultCargoOperationDto>().ReverseMap();

        }
    }
}

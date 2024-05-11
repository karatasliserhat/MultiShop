using AutoMapper;
using MultiShop.Order.Application.Features.MediatR.Commands;
using MultiShop.Order.Application.Features.MediatR.Results;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Mappings
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Address, GetAdressByIdQueryResult>().ReverseMap();
            CreateMap<Address, GetAddressQueryResult>().ReverseMap();
            CreateMap<Address, CreateAddressCommand>().ReverseMap();
            CreateMap<Address, UpdateAddressCommand>().ReverseMap();

            CreateMap<OrderDetail, GetOrderDetailByIdQueryResult>().ReverseMap();
            CreateMap<OrderDetail, GetOrderDetailQueryResult>().ReverseMap();
            CreateMap<OrderDetail, CreateOrderDetailCommand>().ReverseMap();
            CreateMap<OrderDetail, UpdateOrderDetailCommand>().ReverseMap();

            CreateMap<Ordering, GetOrderingByIdQueryResult>().ReverseMap();
            CreateMap<Ordering, GetOrderingQueryResult>().ReverseMap();
            CreateMap<Ordering, CreateOrderingCommand>().ReverseMap();
            CreateMap<Ordering, UpdateOrderingCommand>().ReverseMap();
            CreateMap<Ordering, GetOrderingByUserIdResult>().ReverseMap();
        }
    }
}

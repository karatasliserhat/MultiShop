using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Features.MediatR.Queries;
using MultiShop.Order.Application.Features.MediatR.Results;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.MediatR.Handlers.AdressHandlers
{
    public class GetAdressQueryHandler : IRequestHandler<GetAdressQuery, List<GetAddressQueryResult>>
    {
        private readonly IRepository<Address> _repository;
        private readonly IMapper _mapper;
        public GetAdressQueryHandler(IRepository<Address> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetAddressQueryResult>> Handle(GetAdressQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<GetAddressQueryResult>>(await _repository.GetAllAsync());
        }
    }
}

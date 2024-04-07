using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Features.MediatR.Queries;
using MultiShop.Order.Application.Features.MediatR.Results;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.MediatR.Handlers.AdressHandlers
{
    public class GetAdressByIdQueryHandler : IRequestHandler<GetAddressByIdQuery, GetAdressByIdQueryResult>
    {
        private readonly IRepository<Address> _repository;
        private readonly IMapper _mapper;
        public GetAdressByIdQueryHandler(IRepository<Address> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetAdressByIdQueryResult> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<GetAdressByIdQueryResult>(await _repository.GetByIdAsync(request.AddressId));
        }
    }
}

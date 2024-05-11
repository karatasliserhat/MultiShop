using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Features.MediatR.Queries.OrderingQueries;
using MultiShop.Order.Application.Features.MediatR.Results;
using MultiShop.Order.Application.Interfaces;

namespace MultiShop.Order.Application.Features.MediatR.Handlers.OrderingHandlers
{
    public class GetOrderingByUserIdQueryHandler : IRequestHandler<GetOrderingByUserIdQuery, List<GetOrderingByUserIdResult>>
    {
        private readonly IOrderOrderingRepository _orderOrderingRepository;
        private readonly IMapper _mapper;
        public GetOrderingByUserIdQueryHandler(IOrderOrderingRepository orderOrderingRepository, IMapper mapper)
        {
            _orderOrderingRepository = orderOrderingRepository;
            _mapper = mapper;
        }

        public async Task<List<GetOrderingByUserIdResult>> Handle(GetOrderingByUserIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<GetOrderingByUserIdResult>>(await _orderOrderingRepository.GetListOrderingByUserIdAsync(request.UserId));
        }
    }
}

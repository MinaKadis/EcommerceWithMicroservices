﻿using AutoMapper;

using Basket.Application.Queries;
using Basket.Application.Responses;
using Basket.Core.Repositories;

using MediatR;

namespace Basket.Application.Handlers.Queries
{
    public class GetBasketByUserNameQueryHandler : IRequestHandler<GetBasketByUserNameQuery, ShoppingCartResponse>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public GetBasketByUserNameQueryHandler(IBasketRepository basketRepository, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }

        public async Task<ShoppingCartResponse> Handle(GetBasketByUserNameQuery request, CancellationToken cancellationToken)
        {
            var basket = await _basketRepository.GetBasket(request.UserName);
            return _mapper.Map<ShoppingCartResponse>(basket);
        }
    }
}

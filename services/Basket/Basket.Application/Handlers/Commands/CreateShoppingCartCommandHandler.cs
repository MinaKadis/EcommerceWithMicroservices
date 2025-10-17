using AutoMapper;

using Basket.Application.Commands;
using Basket.Application.Responses;
using Basket.Core.Entities;
using Basket.Core.Repositories;

using MediatR;

namespace Basket.Application.Handlers.Commands
{
    public class CreateShoppingCartCommandHandler : IRequestHandler<CreateShoppingCartCommand, ShoppingCartResponse>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public CreateShoppingCartCommandHandler(IBasketRepository basketRepository, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }
        public async Task<ShoppingCartResponse> Handle(CreateShoppingCartCommand request, CancellationToken cancellationToken)
        {
            //TODO will integrate with Discount Service
            var shoppingCart = await _basketRepository.UpdateBasket(new ShoppingCart()
            {
                UserName = request.UserName,
                Items = request.Items
            });

            return _mapper.Map<ShoppingCartResponse>(shoppingCart);
        }
    }
}

using AutoMapper;

using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Handlers.Queries
{
    public class GetAllProductsByNameQueryHandler : IRequestHandler<GetProductsByNameQuery, IList<ProductResponseDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductsByNameQueryHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<IList<ProductResponseDto>> Handle(GetProductsByNameQuery request, CancellationToken cancellationToken)
        {
            var productList = await _productRepository.GetAllProductsByName(request.Name);
            var productResponseList = _mapper.Map<IList<ProductResponseDto>>(productList);
            return productResponseList;
        }
    }
}

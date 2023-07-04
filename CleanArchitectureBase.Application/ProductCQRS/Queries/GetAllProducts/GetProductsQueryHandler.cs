using AutoMapper;
using CleanArchitectureBase.Application.Common.Interfaces;
using CleanArchitectureBase.Application.Common.Models;
using CleanArchitectureBase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.ProductCQRS.Queries.GetAllProducts
{
    public class GetProductsQueryHandler : BaseCommandHandler<GetProductsQuery, PaginatedList<GetAllProductResponse>>
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IProductRepository _productRepository2;

        public GetProductsQueryHandler(IMapper mapper, IService service, IGenericRepository<Product> productRepository, IProductRepository productRepository2) : base(mapper, service)
        {
            _productRepository = productRepository;
            _productRepository2 = productRepository2;
        }
        public override async Task<PaginatedList<GetAllProductResponse>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var rs = await _productRepository2.GetAllProducts(
                offset: request.Offset,
                limit: request.Limit);
            return _mapper.Map<PaginatedList<GetAllProductResponse>>(rs);
        }
    }
}

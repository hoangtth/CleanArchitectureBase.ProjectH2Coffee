using AutoMapper;
using CleanArchitectureBase.Application.Common.Interfaces;
using CleanArchitectureBase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.ProductCQRS.Queries.GetAllProducts
{
    public class GetProductsQueryHandler : BaseCommandHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IProductRepository _productRepository2;

        public GetProductsQueryHandler(IMapper mapper, IService service, IGenericRepository<Product> productRepository, IProductRepository productRepository2) : base(mapper, service)
        {
            _productRepository = productRepository;
            _productRepository2 = productRepository2;
        }
        public override async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var rs = await _productRepository2.GetAllProducts();
            return rs;
        }
    }
}

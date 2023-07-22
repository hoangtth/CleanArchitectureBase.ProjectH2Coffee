using AutoMapper;
using CleanArchitectureBase.Application.Common.Interfaces;
using CleanArchitectureBase.Application.OrderCQRS.Queries;
using CleanArchitectureBase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.ProductCQRS.Queries.GetTotalProductActive
{
    public class GetTotalProductQueryHandler : BaseCommandHandler<GetTotalProductActiveQuery, GetTotalProductActiveResponseModel>
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IProductRepository _productRepository2;
        public GetTotalProductQueryHandler(IMapper mapper, IService service, IGenericRepository<Product> productRepository, IProductRepository productRepository2) : base(mapper, service)
        {
            _productRepository = productRepository;
            _productRepository2 = productRepository2;
        }

        public override async Task<GetTotalProductActiveResponseModel> Handle(GetTotalProductActiveQuery request, CancellationToken cancellationToken)
        {
            var rs = await _productRepository2.GetTotalProduct();
            var total = new GetTotalProductActiveResponseModel()
            {
                Total = rs
            };
            return total;
        }
    }
}

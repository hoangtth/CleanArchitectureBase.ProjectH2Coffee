﻿using AutoMapper;
using CleanArchitectureBase.Application.Common.Interfaces;
using CleanArchitectureBase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.GetProduct.Queries
{
    public class GetProductQueryHandler : BaseCommandHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly IGenericRepository<Product> _productRepository;
        public GetProductQueryHandler(IMapper mapper,IService service, IGenericRepository<Product> productRepository) : base(mapper, service)
        {
            _productRepository = productRepository;
        }
        public override async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var rs = await _productRepository.GetAll();
            return rs;
        }
    }
}

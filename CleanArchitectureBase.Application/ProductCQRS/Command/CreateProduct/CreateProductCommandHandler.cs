using AutoMapper;
using CleanArchitectureBase.Application.Common.Interfaces;
using CleanArchitectureBase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.ProductCQRS.Command.CreateProduct
{
    public class CreateProductCommandHandler : BaseCommandHandler<CreateProductCommand, bool>
    {
        private readonly IGenericRepository<Product> _productRepository;
        public CreateProductCommandHandler(IMapper mapper, IService service,IGenericRepository<Product> productRepository) : base(mapper, service)
        {
            _productRepository = productRepository;
        }

        public override async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            await _productRepository.Add(product);
            return true;
        }
    }
}

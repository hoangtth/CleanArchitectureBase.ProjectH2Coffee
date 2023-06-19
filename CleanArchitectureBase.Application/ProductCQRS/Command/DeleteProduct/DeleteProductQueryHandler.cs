using AutoMapper;
using CleanArchitectureBase.Application.Common.Exceptions;
using CleanArchitectureBase.Application.Common.Interfaces;
using CleanArchitectureBase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.ProductCQRS.Command.DeleteProduct
{
    public class DeleteProductQueryHandler : BaseCommandHandler<DeleteProductById, bool>
    {

        private readonly IGenericRepository<Product> _productRepository;

        public DeleteProductQueryHandler(IMapper mapper,IService service,IGenericRepository<Product> productRepository) : base(mapper,service)
        {
            _productRepository = productRepository;
        }

        public override async Task<bool> Handle(DeleteProductById request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetById(request.Id);
            if(product == null)
            {
                throw new HttpStatusException("Product not exist", Domain.Helpers.ECode.BadRequest);
            }

            _productRepository.Remove(product);

            return true;
        }
    }
}

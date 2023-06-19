using Amazon.Runtime.Internal;
using AutoMapper;
using CleanArchitectureBase.Application.Common.Exceptions;
using CleanArchitectureBase.Application.Common.Interfaces;
using CleanArchitectureBase.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.ProductCQRS.Command.UpdateProduct
{
    public class UpdateProductCommandHandler : BaseCommandHandler<UpdateProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandHandler(IMapper mapper,IService service,IProductRepository productRepository) : base(mapper,service)
        {
            _productRepository = productRepository;
        }

        public override async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetById(request.Id);
            if (product == null)
            {
                throw new HttpStatusException("Not Found", Domain.Helpers.ECode.BadRequest);
            }

            var productUpdated = _mapper.Map(request,product);

            var rs = await _productRepository.UpdateProduct(productUpdated);

            return rs;
        }
    }
}

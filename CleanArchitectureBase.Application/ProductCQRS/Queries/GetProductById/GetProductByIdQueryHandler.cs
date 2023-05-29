using AutoMapper;
using CleanArchitectureBase.Application.Common.Exceptions;
using CleanArchitectureBase.Application.Common.Interfaces;
using CleanArchitectureBase.Domain.Entities;
using CleanArchitectureBase.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.ProductCQRS.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : BaseCommandHandler<GetProductByIdQuery, Product>
    {
        private readonly IGenericRepository<Product> _productRepository;
        public GetProductByIdQueryHandler(IMapper mapper,IService service,IGenericRepository<Product> productRepository) : base(mapper,service) 
        {
            _productRepository = productRepository;
        }
        public override async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var rs = await _productRepository.GetById(request.Id);
            if(rs == null)  throw new HttpStatusException(string.Format(ErrorMessage.NotFound,"ProductID"),ECode.BadRequest,(int)HttpStatusCode.BadRequest);
            return rs;
        }
    }
}

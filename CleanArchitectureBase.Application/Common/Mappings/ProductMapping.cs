using AutoMapper;
using CleanArchitectureBase.Application.ProductCQRS.Command.UpdateProduct;
using CleanArchitectureBase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.Common.Mappings
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<UpdateProductCommand, Product>();
        }
    }
}

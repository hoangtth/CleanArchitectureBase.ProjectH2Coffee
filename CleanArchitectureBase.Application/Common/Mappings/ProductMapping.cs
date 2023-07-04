using AutoMapper;
using CleanArchitectureBase.Application.Common.Models;
using CleanArchitectureBase.Application.ProductCQRS.Command.CreateProduct;
using CleanArchitectureBase.Application.ProductCQRS.Command.UpdateProduct;
using CleanArchitectureBase.Application.ProductCQRS.Queries.GetAllProducts;
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
            CreateMap<CreateProductCommand, Product>();
            CreateMap<Product,GetAllProductResponse>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
            CreateMap<PaginatedList<Product>, PaginatedList<GetAllProductResponse>>();
        }
    }
}

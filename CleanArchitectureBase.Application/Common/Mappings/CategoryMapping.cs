using AutoMapper;
using CleanArchitectureBase.Application.CategoryCQRS.Commands.UpdateCategory;
using CleanArchitectureBase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.Common.Mappings
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<UpdateCategoryCommand, Category>();
        }
    }
}

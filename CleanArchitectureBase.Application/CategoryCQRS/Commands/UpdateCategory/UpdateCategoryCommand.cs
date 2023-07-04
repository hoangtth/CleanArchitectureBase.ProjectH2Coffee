using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.CategoryCQRS.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<bool>
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}

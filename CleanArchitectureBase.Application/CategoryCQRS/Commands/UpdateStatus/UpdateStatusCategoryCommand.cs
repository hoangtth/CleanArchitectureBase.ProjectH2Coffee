using CleanArchitectureBase.Domain.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.CategoryCQRS.Commands.UpdateStatus
{
    public class UpdateStatusCategoryCommand: IRequest<bool>
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public EStatus Status { get; set; } 
    }
}

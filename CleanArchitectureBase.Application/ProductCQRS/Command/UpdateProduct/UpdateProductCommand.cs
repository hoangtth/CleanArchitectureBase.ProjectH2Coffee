﻿using Amazon.Runtime.Internal;
using CleanArchitectureBase.Domain.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.ProductCQRS.Command.UpdateProduct
{
    public class UpdateProductCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        [Required]
        public int UnitsInStock { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public bool IsSignature { get; set; }

        public decimal Discount { get; set; } = 0;

        [Required]
        public EStatus Status { get; set; }

        public string ImageUrl { get; set; } = string.Empty;
    }
}

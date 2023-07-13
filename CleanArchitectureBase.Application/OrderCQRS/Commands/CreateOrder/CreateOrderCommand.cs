using Amazon.Runtime.Internal;
using CleanArchitectureBase.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.OrderCQRS.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<bool>
    {
        public string Note { get; set; } = string.Empty;

        public string EmployeeName { get; set; }

        public List<OrderDetailsDto> OrderDetails { get; set; }
    }

    public class OrderDetailsDto
    {
        public string ProductName { get; set; }

        public string ProductImage { get; set; }

        public string ProductPrice { get; set; }

        public int Quantity { get; set; }
    }
}

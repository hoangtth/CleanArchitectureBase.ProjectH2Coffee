using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.OrderCQRS.Queries
{
    public class GetAllOrdersQueryResponse
    {
        public int Id { get; set; }

        public string? Note { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string? CustomerName { get; set; }

        public string EmployeeName { get; set; }

        public decimal TotalCost { get; set; }
    }
}

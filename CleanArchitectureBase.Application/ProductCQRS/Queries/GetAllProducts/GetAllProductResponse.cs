using CleanArchitectureBase.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.ProductCQRS.Queries.GetAllProducts
{
    public class GetAllProductResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public int UnitsInStock { get; set; }

        public string Description { get; set; }

        public decimal UnitPrice { get; set; }

        public bool IsSignature { get; set; }

        public decimal Discount { get; set; } = 0;

        public EStatus Status { get; set; }

        public string ImageUrl { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string CategoryName { get; set; }
    }
}

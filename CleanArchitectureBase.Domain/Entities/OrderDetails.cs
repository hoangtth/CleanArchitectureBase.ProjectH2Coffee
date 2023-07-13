using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Domain.Entities
{
    public class OrderDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int OrderId { get; set; }

        public string ProductName { get; set; }

        public string ProductImage { get; set; }

        public string ProductPrice { get; set; }

        public int Quantity { get; set; }

        public Order Order { get; set; }
    }
}

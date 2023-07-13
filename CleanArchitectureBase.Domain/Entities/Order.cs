using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Domain.Entities
{
    public class Order
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Note { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string EmployeeName { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}

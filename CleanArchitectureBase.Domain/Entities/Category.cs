using CleanArchitectureBase.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Domain.Entities
{
    public class Category
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(100)]
        [Required]
        public string Name { get; set; }

        public DateTime CreatedDate = DateTime.Now;

        [Required]
        public EStatus Status { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}

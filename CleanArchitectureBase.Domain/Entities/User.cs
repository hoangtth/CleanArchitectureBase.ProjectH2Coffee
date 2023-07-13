using CleanArchitectureBase.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Domain.Entities
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string City { get; set; }

        public DateTime StartDate { get; set; } = DateTime.Now;

        public string? Phone { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public EStatus Status { get; set; }

        public int RoleId { get; set; }

        public Role Role { get; set; }
    }
}

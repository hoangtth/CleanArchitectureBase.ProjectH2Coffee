using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.Common.Models
{
    public class PaginatedList<T>
    {
        public long Total { get; set; }


        public IList<T> Items { get; set; }
    }
}

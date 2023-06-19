using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.Common.Models
{
    public class PagingQueryModel
    {
        public int Offset { get; set; } = 0;

        public int Limit { get; set; } = 10;
    }
}

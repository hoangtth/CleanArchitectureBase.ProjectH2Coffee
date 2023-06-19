using Amazon.Runtime.Internal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.ProductCQRS.Command.DeleteProduct
{
    public class DeleteProductById : IRequest<bool>
    {
        public int Id { get; set; }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.UserCQRS.Queries.GetUserDetail
{
    public class GetUserDetailQuery : IRequest<GetUserDetailResponseModel>
    {
        [Required]
        public int Id { get; set; }
    }
}

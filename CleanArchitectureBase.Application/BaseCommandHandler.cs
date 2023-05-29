using AutoMapper;
using CleanArchitectureBase.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application
{
    public abstract class BaseCommandHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        protected readonly IMapper _mapper;
        protected readonly IService _service;
        //protected readonly IGenericRepository<>

        public BaseCommandHandler(IMapper mapper,IService service)
        {
            _mapper = mapper;
            _service = service;
        }
        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}

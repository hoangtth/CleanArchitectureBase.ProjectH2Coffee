using AutoMapper;
using CleanArchitectureBase.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.PermissionCQRS
{
    public class GetPermissionsByRoleCommandHandler : BaseCommandHandler<GetPermissionsByRoleCommand, List<GetPermissionsByRoleResponseModel>>
    {
        private readonly IPermissionRepository _permissionRepository;
        public GetPermissionsByRoleCommandHandler(IMapper mapper, IService service,IPermissionRepository permissionRepository) : base(mapper, service)
        {
            _permissionRepository = permissionRepository;
        }

        public override async Task<List<GetPermissionsByRoleResponseModel>> Handle(GetPermissionsByRoleCommand request, CancellationToken cancellationToken)
        {
            var permissions = await _permissionRepository.GetPermissionsByRoleAsync(request.RoleName);
            return _mapper.Map<List<GetPermissionsByRoleResponseModel>>(permissions);
        }
    }
}

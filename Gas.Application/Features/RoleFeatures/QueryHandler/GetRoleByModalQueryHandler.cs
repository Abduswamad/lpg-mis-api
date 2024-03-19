using AutoMapper;
using MediatR;
using Gas.Domain.Entities;
using Gas.Utils;
using Gas.Domain.Entity.CompanyManagement;
using Gas.Services.CompanyManagement;
using Gas.Model.CompanyManagement;

namespace Gas.Application.Features.RoleFeatures.QueryHandler
{
    public record GetRoleByModalQuery(GetRoleModel? rqModel) : IRequest<Result<IList<RoleEntity>>>;

    internal class GetRoleByModalQueryHandler : IRequestHandler<GetRoleByModalQuery, Result<IList<RoleEntity>>>
    {
        public async Task<Result<IList<RoleEntity>>> Handle(GetRoleByModalQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new RoleService().GetRole(request.rqModel);
                if (resp.Count>0)
                {
                    return await Result<IList<RoleEntity>>.SuccessAsync(resp);
                }
                else
                {
                    return await Result<IList<RoleEntity>>.FailureAsync("No Data Available");
                }
            }
            catch (Exception e)
            {
                return await Result<IList<RoleEntity>>.FailureAsync(e.Message);
            }
        }

    }

}

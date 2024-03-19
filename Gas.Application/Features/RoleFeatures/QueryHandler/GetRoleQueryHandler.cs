using AutoMapper;
using Gas.Domain.Entity.CompanyManagement;
using Gas.Services.CompanyManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.RoleFeatures.QueryHandler
{
    public record GetRoleQuery() : IRequest<Result<IList<RoleEntity>>>;

    internal class GetRoleQueryHandler : IRequestHandler<GetRoleQuery, Result<IList<RoleEntity>>>
    {
        public async Task<Result<IList<RoleEntity>>> Handle(GetRoleQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new RoleService().GetRole();
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

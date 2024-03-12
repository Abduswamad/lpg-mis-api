using AutoMapper;
using Gas.Domain.Entity.CompanyManagement;
using Gas.Services.CompanyManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.StaffroleFeatures.QueryHandler
{
    public record GetStaffroleQuery() : IRequest<Result<IList<StaffRoleEntity>>>;

    internal class GetStaffroleQueryHandler : IRequestHandler<GetStaffroleQuery, Result<IList<StaffRoleEntity>>>
    {
        private readonly IMapper _mapper;
        public GetStaffroleQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<IList<StaffRoleEntity>>> Handle(GetStaffroleQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new StaffroleService().GetStaffrole();
                if (resp.Count>0)
                {
                    return await Result<IList<StaffRoleEntity>>.SuccessAsync(resp);
                }
                else
                {
                    return await Result<IList<StaffRoleEntity>>.FailureAsync("No Data Available");
                }
            }
            catch (Exception e)
            {
                return await Result<IList<StaffRoleEntity>>.FailureAsync(e.Message);
            }
        }

    }

}

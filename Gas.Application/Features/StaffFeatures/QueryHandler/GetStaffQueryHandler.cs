using AutoMapper;
using Gas.Domain.Entity.CompanyManagement;
using Gas.Services.CompanyManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.UserFeatures.QueryHandler
{
    public record GetStaffQuery() : IRequest<Result<IList<StaffEntity>>>;

    internal class GetStaffQueryHandler : IRequestHandler<GetStaffQuery, Result<IList<StaffEntity>>>
    {
        private readonly IMapper _mapper;
        public GetStaffQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<IList<StaffEntity>>> Handle(GetStaffQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new StaffService().GetAllStaff();
                if (resp.Count>0)
                {
                    return await Result<IList<StaffEntity>>.SuccessAsync(resp);
                }
                else
                {
                    return await Result<IList<StaffEntity>>.FailureAsync("No Data Available");
                }
            }
            catch (Exception e)
            {
                return await Result<IList<StaffEntity>>.FailureAsync(e.Message);
            }
        }

    }

}

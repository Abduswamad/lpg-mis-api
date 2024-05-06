using AutoMapper;
using Gas.Domain.Entity.CompanyManagement;
using Gas.Services.CompanyManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.StaffFeatures.QueryHandler
{
    public record GetStaffQuery(int SuperDealerId) : IRequest<Result<IList<StaffEntity>>>;

    internal class GetStaffQueryHandler : IRequestHandler<GetStaffQuery, Result<IList<StaffEntity>>>
    {
        public async Task<Result<IList<StaffEntity>>> Handle(GetStaffQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new StaffService().GetStaff().Where(x => x.Super_dealer_id == request.SuperDealerId).ToList();
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

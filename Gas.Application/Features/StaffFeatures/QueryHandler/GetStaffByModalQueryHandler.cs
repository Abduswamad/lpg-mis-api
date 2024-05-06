using AutoMapper;
using MediatR;
using Gas.Domain.Entities;
using Gas.Utils;
using Gas.Domain.Entity.CompanyManagement;
using Gas.Services.CompanyManagement;
using Gas.Model.CompanyManagement;

namespace Gas.Application.Features.StaffFeatures.QueryHandler
{
    public record GetStaffByModalQuery(GetStaffModel? RqModel,int SuperDealerId) : IRequest<Result<IList<StaffEntity>>>;

    internal class GetStaffByModalQueryHandler : IRequestHandler<GetStaffByModalQuery, Result<IList<StaffEntity>>>
    {
        public async Task<Result<IList<StaffEntity>>> Handle(GetStaffByModalQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new StaffService().GetStaff(request.RqModel).Where(x => x.Super_dealer_id == request.SuperDealerId).ToList();
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

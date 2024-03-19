using AutoMapper;
using MediatR;
using Gas.Domain.Entities;
using Gas.Utils;
using Gas.Domain.Entity.CompanyManagement;
using Gas.Services.CompanyManagement;
using Gas.Model.CompanyManagement;

namespace Gas.Application.Features.StaffFeatures.QueryHandler
{
    public record GetStaffByModalQuery(GetStaffModel? rqModel) : IRequest<Result<IList<StaffEntity>>>;

    internal class GetStaffByModalQueryHandler : IRequestHandler<GetStaffByModalQuery, Result<IList<StaffEntity>>>
    {
        public async Task<Result<IList<StaffEntity>>> Handle(GetStaffByModalQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new StaffService().GetStaff(request.rqModel);
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

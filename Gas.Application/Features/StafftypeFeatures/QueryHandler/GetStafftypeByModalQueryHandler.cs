using AutoMapper;
using MediatR;
using Gas.Domain.Entities;
using Gas.Utils;
using Gas.Domain.Entity.CompanyManagement;
using Gas.Services.CompanyManagement;
using Gas.Model.CompanyManagement;

namespace Gas.Application.Features.StafftypeFeatures.QueryHandler
{
    public record GetStafftypeByModalQuery(GetStafftypeModel? rqModel) : IRequest<Result<IList<StaffTypeEntity>>>;

    internal class GetStafftypeByModalQueryHandler : IRequestHandler<GetStafftypeByModalQuery, Result<IList<StaffTypeEntity>>>
    {
        public async Task<Result<IList<StaffTypeEntity>>> Handle(GetStafftypeByModalQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new StafftypeService().GetStafftype(request.rqModel);
                if (resp.Count>0)
                {
                    return await Result<IList<StaffTypeEntity>>.SuccessAsync(resp);
                }
                else
                {
                    return await Result<IList<StaffTypeEntity>>.FailureAsync("No Data Available");
                }
            }
            catch (Exception e)
            {
                return await Result<IList<StaffTypeEntity>>.FailureAsync(e.Message);
            }
        }

    }

}

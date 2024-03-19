using AutoMapper;
using MediatR;
using Gas.Domain.Entities;
using Gas.Utils;
using Gas.Domain.Entity.PublicManagement;
using Gas.Services.PublicManagement;
using Gas.Model.PublicManagement;

namespace Gas.Application.Features.DistrictFeatures.QueryHandler
{
    public record GetDistrictByModalQuery(GetDistrictModel? rqModel) : IRequest<Result<IList<DistrictEntity>>>;

    internal class GetDistrictByModalQueryHandler : IRequestHandler<GetDistrictByModalQuery, Result<IList<DistrictEntity>>>
    {
       
        public async Task<Result<IList<DistrictEntity>>> Handle(GetDistrictByModalQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new DistrictService().GetDistrict(request.rqModel);
                if (resp.Count>0)
                {
                    return await Result<IList<DistrictEntity>>.SuccessAsync(resp);
                }
                else
                {
                    return await Result<IList<DistrictEntity>>.FailureAsync("No Data Available");
                }
            }
            catch (Exception e)
            {
                return await Result<IList<DistrictEntity>>.FailureAsync(e.Message);
            }
        }

    }

}

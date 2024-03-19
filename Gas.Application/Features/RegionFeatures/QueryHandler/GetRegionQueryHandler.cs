using AutoMapper;
using Gas.Domain.Entity.PublicManagement;
using Gas.Services.PublicManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.RegionFeatures.QueryHandler
{
    public record GetRegionQuery() : IRequest<Result<IList<RegionEntity>>>;

    internal class GetRegionQueryHandler : IRequestHandler<GetRegionQuery, Result<IList<RegionEntity>>>
    {
        public async Task<Result<IList<RegionEntity>>> Handle(GetRegionQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new RegionService().GetRegion();
                if (resp.Count>0)
                {
                    return await Result<IList<RegionEntity>>.SuccessAsync(resp);
                }
                else
                {
                    return await Result<IList<RegionEntity>>.FailureAsync("No Data Available");
                }
            }
            catch (Exception e)
            {
                return await Result<IList<RegionEntity>>.FailureAsync(e.Message);
            }
        }

    }

}

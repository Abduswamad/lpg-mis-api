using AutoMapper;
using Gas.Domain.Entity.StoreManagement;
using Gas.Services.StoreManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.CylinderstatusFeatures.QueryHandler
{
    public record GetCylinderstatusQuery() : IRequest<Result<IList<CylinderstatusEntity>>>;

    internal class GetCylinderstatusQueryHandler : IRequestHandler<GetCylinderstatusQuery, Result<IList<CylinderstatusEntity>>>
    {
        public async Task<Result<IList<CylinderstatusEntity>>> Handle(GetCylinderstatusQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new CylinderstatusService().GetCylinderstatus();
                if (resp.Count>0)
                {
                    return await Result<IList<CylinderstatusEntity>>.SuccessAsync(resp);
                }
                else
                {
                    return await Result<IList<CylinderstatusEntity>>.FailureAsync("No Data Available");
                }
            }
            catch (Exception e)
            {
                return await Result<IList<CylinderstatusEntity>>.FailureAsync(e.Message);
            }
        }

    }

}

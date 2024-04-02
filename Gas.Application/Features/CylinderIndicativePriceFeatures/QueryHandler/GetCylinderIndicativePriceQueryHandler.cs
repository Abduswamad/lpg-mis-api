using Gas.Domain.Entity.SalesManagement;
using Gas.Services.SalesManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.CylinderIndicativePriceFeatures.QueryHandler
{
    public record GetCylinderIndicativePriceQuery() : IRequest<Result<IList<CylinderIndicativePriceEntity>>>;

    internal class GetCylinderIndicativePriceQueryHandler : IRequestHandler<GetCylinderIndicativePriceQuery, Result<IList<CylinderIndicativePriceEntity>>>
    {
        public async Task<Result<IList<CylinderIndicativePriceEntity>>> Handle(GetCylinderIndicativePriceQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new CylinderIndicativePriceService().GetCylinderIndicativePrice();
                if (resp.Count>0)
                {
                    return await Result<IList<CylinderIndicativePriceEntity>>.SuccessAsync(resp);
                }
                else
                {
                    return await Result<IList<CylinderIndicativePriceEntity>>.FailureAsync("No Data Available");
                }
            }
            catch (Exception e)
            {
                return await Result<IList<CylinderIndicativePriceEntity>>.FailureAsync(e.Message);
            }
        }

    }

}

using Gas.Domain.Entity.SalesManagement;
using Gas.Services.SalesManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.AccessoryIndicativePriceFeatures.QueryHandler
{
    public record GetAccessoryIndicativePriceQuery() : IRequest<Result<IList<AccessoryIndicativePriceEntity>>>;

    internal class GetAccessoryIndicativePriceQueryHandler : IRequestHandler<GetAccessoryIndicativePriceQuery, Result<IList<AccessoryIndicativePriceEntity>>>
    {
        public async Task<Result<IList<AccessoryIndicativePriceEntity>>> Handle(GetAccessoryIndicativePriceQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new AccessoryIndicativePriceService().GetAccessoryIndicativePrice();
                if (resp.Count>0)
                {
                    return await Result<IList<AccessoryIndicativePriceEntity>>.SuccessAsync(resp);
                }
                else
                {
                    return await Result<IList<AccessoryIndicativePriceEntity>>.FailureAsync("No Data Available");
                }
            }
            catch (Exception e)
            {
                return await Result<IList<AccessoryIndicativePriceEntity>>.FailureAsync(e.Message);
            }
        }

    }

}

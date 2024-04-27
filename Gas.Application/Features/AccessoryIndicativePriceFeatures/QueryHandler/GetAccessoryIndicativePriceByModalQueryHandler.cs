using Gas.Domain.Entity.SalesManagement;
using Gas.Model.SalesManagement;
using Gas.Services.SalesManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.AccessoryIndicativePriceFeatures.QueryHandler
{
    public record GetAccessoryIndicativePriceByModalQuery(GetAccessoryIndicativePriceModel? RqModel) : IRequest<Result<IList<AccessoryIndicativePriceEntity>>>;

    internal class GetAccessoryIndicativePriceByModalQueryHandler : IRequestHandler<GetAccessoryIndicativePriceByModalQuery, Result<IList<AccessoryIndicativePriceEntity>>>
    {
        public async Task<Result<IList<AccessoryIndicativePriceEntity>>> Handle(GetAccessoryIndicativePriceByModalQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new AccessoryIndicativePriceService().GetAccessoryIndicativePrice(request.RqModel);
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

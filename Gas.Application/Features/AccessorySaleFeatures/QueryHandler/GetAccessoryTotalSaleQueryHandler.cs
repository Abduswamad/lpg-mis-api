using Gas.Domain.Entity.SalesManagement;
using Gas.Model.SalesManagement;
using Gas.Services.SalesManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.AccessorySaleFeatures.QueryHandler
{
    public record GetAccessoryTotalSaleQuery(SalesTotalModel? rqModel) : IRequest<Result<IList<AccessoryTotalSaleEntity>>>;

    internal class GetAccessoryTotalSaleQueryHandler : IRequestHandler<GetAccessoryTotalSaleQuery, Result<IList<AccessoryTotalSaleEntity>>>
    {
        public async Task<Result<IList<AccessoryTotalSaleEntity>>> Handle(GetAccessoryTotalSaleQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new AccessorySaleService().GetAccessoryTotalSale(request.rqModel);
                if (resp.Count>0)
                {
                    return await Result<IList<AccessoryTotalSaleEntity>>.SuccessAsync(resp);
                }
                else
                {
                    return await Result<IList<AccessoryTotalSaleEntity>>.FailureAsync("No Data Available");
                }
            }
            catch (Exception e)
            {
                return await Result<IList<AccessoryTotalSaleEntity>>.FailureAsync(e.Message);
            }
        }

    }

}

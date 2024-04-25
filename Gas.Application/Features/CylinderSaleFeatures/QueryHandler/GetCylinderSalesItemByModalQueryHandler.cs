using Gas.Domain.Entity.SalesManagement;
using Gas.Model.SalesManagement;
using Gas.Services.SalesManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.CylinderSaleFeatures.QueryHandler
{
    public record GetCylinderSalesItemByModalQuery(GetCylinderSalesItemModel? RqModel) : IRequest<Result<IList<CylinderSalesItemEntity>>>;

    internal class GetCylinderSalesItemByModalQueryHandler : IRequestHandler<GetCylinderSalesItemByModalQuery, Result<IList<CylinderSalesItemEntity>>>
    {
        public async Task<Result<IList<CylinderSalesItemEntity>>> Handle(GetCylinderSalesItemByModalQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new CylinderSaleService().GetCylinderSalesItem(request.RqModel);
                if (resp.Count>0)
                {
                    return await Result<IList<CylinderSalesItemEntity>>.SuccessAsync(resp);
                }
                else
                {
                    return await Result<IList<CylinderSalesItemEntity>>.FailureAsync("No Data Available");
                }
            }
            catch (Exception e)
            {
                return await Result<IList<CylinderSalesItemEntity>>.FailureAsync(e.Message);
            }
        }

    }

}

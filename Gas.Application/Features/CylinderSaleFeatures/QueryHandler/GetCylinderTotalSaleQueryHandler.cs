using Gas.Domain.Entity.SalesManagement;
using Gas.Model.SalesManagement;
using Gas.Services.SalesManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.CylinderSaleFeatures.QueryHandler
{
    public record GetCylinderTotalSaleQuery(SalesTotalModel? RqModel) : IRequest<Result<IList<CylinderTotalSaleEntity>>>;

    internal class GetCylinderTotalSaleQueryHandler : IRequestHandler<GetCylinderTotalSaleQuery, Result<IList<CylinderTotalSaleEntity>>>
    {
        public async Task<Result<IList<CylinderTotalSaleEntity>>> Handle(GetCylinderTotalSaleQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new CylinderSaleService().GetCylinderTotalSale(request.RqModel);
                if (resp.Count>0)
                {
                    return await Result<IList<CylinderTotalSaleEntity>>.SuccessAsync(resp);
                }
                else
                {
                    return await Result<IList<CylinderTotalSaleEntity>>.FailureAsync("No Data Available");
                }
            }
            catch (Exception e)
            {
                return await Result<IList<CylinderTotalSaleEntity>>.FailureAsync(e.Message);
            }
        }

    }

}

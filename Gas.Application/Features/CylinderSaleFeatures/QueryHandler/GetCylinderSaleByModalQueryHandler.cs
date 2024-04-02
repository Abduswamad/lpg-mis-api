using Gas.Domain.Entity.SalesManagement;
using Gas.Model.SalesManagement;
using Gas.Services.SalesManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.CylinderSaleFeatures.QueryHandler
{
    public record GetCylinderSaleByModalQuery(GetCylinderSaleModel? rqModel) : IRequest<Result<IList<CylinderSaleEntity>>>;

    internal class GetCylinderSaleByModalQueryHandler : IRequestHandler<GetCylinderSaleByModalQuery, Result<IList<CylinderSaleEntity>>>
    {
        public async Task<Result<IList<CylinderSaleEntity>>> Handle(GetCylinderSaleByModalQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new CylinderSaleService().GetCylinderSale(request.rqModel);
                if (resp.Count>0)
                {
                    return await Result<IList<CylinderSaleEntity>>.SuccessAsync(resp);
                }
                else
                {
                    return await Result<IList<CylinderSaleEntity>>.FailureAsync("No Data Available");
                }
            }
            catch (Exception e)
            {
                return await Result<IList<CylinderSaleEntity>>.FailureAsync(e.Message);
            }
        }

    }

}

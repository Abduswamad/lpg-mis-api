using Gas.Domain.Entity.SalesManagement;
using Gas.Model.SalesManagement;
using Gas.Services.SalesManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.AccessorySaleFeatures.QueryHandler
{
    public record GetAccessorySalesItemByModalQuery(GetAccessorySalesItemModel? RqModel) : IRequest<Result<IList<AccessorySalesItemEntity>>>;

    internal class GetAccessorySalesItemByModalQueryHandler : IRequestHandler<GetAccessorySalesItemByModalQuery, Result<IList<AccessorySalesItemEntity>>>
    {
        public async Task<Result<IList<AccessorySalesItemEntity>>> Handle(GetAccessorySalesItemByModalQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new AccessorySaleService().GetAccessorySalesItem(request.RqModel);
                if (resp.Count>0)
                {
                    return await Result<IList<AccessorySalesItemEntity>>.SuccessAsync(resp);
                }
                else
                {
                    return await Result<IList<AccessorySalesItemEntity>>.FailureAsync("No Data Available");
                }
            }
            catch (Exception e)
            {
                return await Result<IList<AccessorySalesItemEntity>>.FailureAsync(e.Message);
            }
        }

    }

}

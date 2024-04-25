using Gas.Domain.Entity.SalesManagement;
using Gas.Model.SalesManagement;
using Gas.Services.SalesManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.AccessorySaleFeatures.QueryHandler
{
    public record GetAccessorySaleByModalQuery(GetAccessorySaleModel? RqModel) : IRequest<Result<IList<AccessorySaleEntity>>>;

    internal class GetAccessorySaleByModalQueryHandler : IRequestHandler<GetAccessorySaleByModalQuery, Result<IList<AccessorySaleEntity>>>
    {
        public async Task<Result<IList<AccessorySaleEntity>>> Handle(GetAccessorySaleByModalQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new AccessorySaleService().GetAccessorySale(request.RqModel);
                if (resp.Count>0)
                {
                    return await Result<IList<AccessorySaleEntity>>.SuccessAsync(resp);
                }
                else
                {
                    return await Result<IList<AccessorySaleEntity>>.FailureAsync("No Data Available");
                }
            }
            catch (Exception e)
            {
                return await Result<IList<AccessorySaleEntity>>.FailureAsync(e.Message);
            }
        }

    }

}

using Gas.Domain.Entity.SalesManagement;
using Gas.Services.SalesManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.AccessorySaleFeatures.QueryHandler
{
    public record GetAccessorySaleQuery() : IRequest<Result<IList<AccessorySaleEntity>>>;

    internal class GetAccessorySaleQueryHandler : IRequestHandler<GetAccessorySaleQuery, Result<IList<AccessorySaleEntity>>>
    {
        public async Task<Result<IList<AccessorySaleEntity>>> Handle(GetAccessorySaleQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new AccessorySaleService().GetAccessorySale();
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

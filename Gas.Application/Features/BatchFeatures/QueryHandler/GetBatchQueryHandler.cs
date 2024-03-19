using AutoMapper;
using Gas.Domain.Entity.StoreManagement;
using Gas.Services.StoreManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.BatchFeatures.QueryHandler
{
    public record GetBatchQuery() : IRequest<Result<IList<BatchEntity>>>;

    internal class GetBatchQueryHandler : IRequestHandler<GetBatchQuery, Result<IList<BatchEntity>>>
    {
        
        public async Task<Result<IList<BatchEntity>>> Handle(GetBatchQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new BatchService().GetBatch();
                if (resp.Count>0)
                {
                    return await Result<IList<BatchEntity>>.SuccessAsync(resp);
                }
                else
                {
                    return await Result<IList<BatchEntity>>.FailureAsync("No Data Available");
                }
            }
            catch (Exception e)
            {
                return await Result<IList<BatchEntity>>.FailureAsync(e.Message);
            }
        }

    }

}

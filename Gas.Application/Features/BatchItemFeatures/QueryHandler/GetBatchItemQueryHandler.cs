using AutoMapper;
using Gas.Domain.Entity.StoreManagement;
using Gas.Services.StoreManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.BatchItemFeatures.QueryHandler
{
    public record GetBatchItemQuery() : IRequest<Result<IList<BatchItemEntity>>>;

    internal class GetBatchItemQueryHandler : IRequestHandler<GetBatchItemQuery, Result<IList<BatchItemEntity>>>
    {
        
        public async Task<Result<IList<BatchItemEntity>>> Handle(GetBatchItemQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new BatchItemService().GetBatchItem();
                if (resp.Count>0)
                {
                    return await Result<IList<BatchItemEntity>>.SuccessAsync(resp);
                }
                else
                {
                    return await Result<IList<BatchItemEntity>>.FailureAsync("No Data Available");
                }
            }
            catch (Exception e)
            {
                return await Result<IList<BatchItemEntity>>.FailureAsync(e.Message);
            }
        }

    }

}

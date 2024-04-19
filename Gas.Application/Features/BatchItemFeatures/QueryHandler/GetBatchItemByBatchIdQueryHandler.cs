using AutoMapper;
using Gas.Domain.Entity.StoreManagement;
using Gas.Services.StoreManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.BatchItemFeatures.QueryHandler
{
    public record GetBatchItemByBatchIdQuery(int BatchId) : IRequest<Result<FullBatchItemEntity>>;

    internal class GetBatchItemByBatchIdQueryHandler : IRequestHandler<GetBatchItemByBatchIdQuery, Result<FullBatchItemEntity>>
    {
        
        public async Task<Result<FullBatchItemEntity>> Handle(GetBatchItemByBatchIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new BatchItemService().GetBatchItemById(request.BatchId);
                if (resp != null)
                {
                    return await Result<FullBatchItemEntity>.SuccessAsync(resp);
                }
                else
                {
                    return await Result<FullBatchItemEntity>.FailureAsync("No Data Available");
                }
            }
            catch (Exception e)
            {
                return await Result<FullBatchItemEntity>.FailureAsync(e.Message);
            }
        }

    }

}

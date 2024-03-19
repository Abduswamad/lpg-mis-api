using AutoMapper;
using Gas.Domain.Entity.StoreManagement;
using Gas.Services.StoreManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.AccessoryBatchItemFeatures.QueryHandler
{
    public record GetAccessoryBatchItemQuery() : IRequest<Result<IList<AccessoryBatchItemEntity>>>;

    internal class GetAccessoryBatchItemQueryHandler : IRequestHandler<GetAccessoryBatchItemQuery, Result<IList<AccessoryBatchItemEntity>>>
    {
        
        public async Task<Result<IList<AccessoryBatchItemEntity>>> Handle(GetAccessoryBatchItemQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new AccessoryBatchItemService().GetAccessoryBatchItem();
                if (resp.Count>0)
                {
                    return await Result<IList<AccessoryBatchItemEntity>>.SuccessAsync(resp);
                }
                else
                {
                    return await Result<IList<AccessoryBatchItemEntity>>.FailureAsync("No Data Available");
                }
            }
            catch (Exception e)
            {
                return await Result<IList<AccessoryBatchItemEntity>>.FailureAsync(e.Message);
            }
        }

    }

}

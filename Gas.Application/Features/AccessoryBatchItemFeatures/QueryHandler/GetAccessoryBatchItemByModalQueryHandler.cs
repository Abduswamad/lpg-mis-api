using AutoMapper;
using MediatR;
using Gas.Domain.Entities;
using Gas.Utils;
using Gas.Domain.Entity.StoreManagement;
using Gas.Services.StoreManagement;
using Gas.Model.StoreManagement;

namespace Gas.Application.Features.AccessoryBatchItemFeatures.QueryHandler
{
    public record GetAccessoryBatchItemByModalQuery(GetAccessoryBatchItemModel? rqModel) : IRequest<Result<IList<AccessoryBatchItemEntity>>>;

    internal class GetAccessoryBatchItemByModalQueryHandler : IRequestHandler<GetAccessoryBatchItemByModalQuery, Result<IList<AccessoryBatchItemEntity>>>
    {
        public async Task<Result<IList<AccessoryBatchItemEntity>>> Handle(GetAccessoryBatchItemByModalQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new AccessoryBatchItemService().GetAccessoryBatchItem(request.rqModel);
                if (resp.Count>0)
                {
                    //var response = _mapper.Map<List<AccessoryBatchItemEntity>>(resp);
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

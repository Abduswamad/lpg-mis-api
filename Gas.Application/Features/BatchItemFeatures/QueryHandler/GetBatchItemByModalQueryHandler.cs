using AutoMapper;
using MediatR;
using Gas.Domain.Entities;
using Gas.Utils;
using Gas.Domain.Entity.StoreManagement;
using Gas.Services.StoreManagement;
using Gas.Model.StoreManagement;

namespace Gas.Application.Features.BatchItemFeatures.QueryHandler
{
    public record GetBatchItemByModalQuery(GetBatchItemModel? rqModel) : IRequest<Result<IList<BatchItemEntity>>>;

    internal class GetBatchItemByModalQueryHandler : IRequestHandler<GetBatchItemByModalQuery, Result<IList<BatchItemEntity>>>
    {
        public async Task<Result<IList<BatchItemEntity>>> Handle(GetBatchItemByModalQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new BatchItemService().GetBatchItem(request.rqModel);
                if (resp.Count>0)
                {
                    //var response = _mapper.Map<List<BatchItemEntity>>(resp);
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

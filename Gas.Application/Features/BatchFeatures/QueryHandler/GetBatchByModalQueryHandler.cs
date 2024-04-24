using Gas.Domain.Entity.StoreManagement;
using Gas.Model.StoreManagement;
using Gas.Services.StoreManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.BatchFeatures.QueryHandler
{
    public record GetBatchByModalQuery(GetBatchModel? RqModel) : IRequest<Result<IList<BatchEntity>>>;

    internal class GetBatchByModalQueryHandler : IRequestHandler<GetBatchByModalQuery, Result<IList<BatchEntity>>>
    {
        public async Task<Result<IList<BatchEntity>>> Handle(GetBatchByModalQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new BatchService().GetBatch(request.RqModel);
                if (resp.Count>0)
                {
                    //var response = _mapper.Map<List<BatchEntity>>(resp);
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

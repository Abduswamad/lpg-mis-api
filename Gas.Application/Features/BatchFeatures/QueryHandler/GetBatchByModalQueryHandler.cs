using AutoMapper;
using MediatR;
using Gas.Domain.Entities;
using Gas.Utils;
using Gas.Domain.Entity.StoreManagement;
using Gas.Services.StoreManagement;
using Gas.Model.StoreManagement;

namespace Gas.Application.Features.BatchFeatures.QueryHandler
{
    public record GetBatchByModalQuery(GetBatchModel? rqModel) : IRequest<Result<IList<BatchEntity>>>;

    internal class GetBatchByModalQueryHandler : IRequestHandler<GetBatchByModalQuery, Result<IList<BatchEntity>>>
    {
        public async Task<Result<IList<BatchEntity>>> Handle(GetBatchByModalQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new BatchService().GetBatch(request.rqModel);
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

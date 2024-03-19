using AutoMapper;
using MediatR;
using Gas.Domain.Entities;
using Gas.Utils;
using Gas.Domain.Entity.StoreManagement;
using Gas.Services.StoreManagement;
using Gas.Model.StoreManagement;

namespace Gas.Application.Features.BatchFeatures.QueryHandler
{
    public record GetAccessoryStockQuery(AccessorystockModel? rqModel) : IRequest<Result<IList<AccessorystockEntity>>>;

    internal class GetAccessoryStockQueryHandler : IRequestHandler<GetAccessoryStockQuery, Result<IList<AccessorystockEntity>>>
    {
        public async Task<Result<IList<AccessorystockEntity>>> Handle(GetAccessoryStockQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new AccessoryBatchItemService().GetAccessorystock(request.rqModel);
                if (resp.Count>0)
                {
                    //var response = _mapper.Map<List<AccessorystockEntity>>(resp);
                    return await Result<IList<AccessorystockEntity>>.SuccessAsync(resp);
                }
                else
                {
                    return await Result<IList<AccessorystockEntity>>.FailureAsync("No Data Available");
                }
            }
            catch (Exception e)
            {
                return await Result<IList<AccessorystockEntity>>.FailureAsync(e.Message);
            }
        }

    }

}

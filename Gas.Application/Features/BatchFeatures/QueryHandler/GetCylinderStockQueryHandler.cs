using AutoMapper;
using MediatR;
using Gas.Domain.Entities;
using Gas.Utils;
using Gas.Domain.Entity.StoreManagement;
using Gas.Services.StoreManagement;
using Gas.Model.StoreManagement;

namespace Gas.Application.Features.BatchFeatures.QueryHandler
{
    public record GetCylinderStockQuery(CylinderstockModel? rqModel) : IRequest<Result<IList<CylinderstockEntity>>>;

    internal class GetCylinderStockQueryHandler : IRequestHandler<GetCylinderStockQuery, Result<IList<CylinderstockEntity>>>
    {
        public async Task<Result<IList<CylinderstockEntity>>> Handle(GetCylinderStockQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new BatchService().GetCylinderstock(request.rqModel);
                if (resp.Count>0)
                {
                    //var response = _mapper.Map<List<CylinderstockEntity>>(resp);
                    return await Result<IList<CylinderstockEntity>>.SuccessAsync(resp);
                }
                else
                {
                    return await Result<IList<CylinderstockEntity>>.FailureAsync("No Data Available");
                }
            }
            catch (Exception e)
            {
                return await Result<IList<CylinderstockEntity>>.FailureAsync(e.Message);
            }
        }

    }

}

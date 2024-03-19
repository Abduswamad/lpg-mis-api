using AutoMapper;
using Gas.Domain.Entity.StoreManagement;
using Gas.Services.StoreManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.BatchtypeFeatures.QueryHandler
{
    public record GetBatchtypeQuery() : IRequest<Result<IList<BatchtypeEntity>>>;

    internal class GetBatchtypeQueryHandler : IRequestHandler<GetBatchtypeQuery, Result<IList<BatchtypeEntity>>>
    {
        public async Task<Result<IList<BatchtypeEntity>>> Handle(GetBatchtypeQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new BatchtypeService().GetBatchtype();
                if (resp.Count>0)
                {
                    return await Result<IList<BatchtypeEntity>>.SuccessAsync(resp);
                }
                else
                {
                    return await Result<IList<BatchtypeEntity>>.FailureAsync("No Data Available");
                }
            }
            catch (Exception e)
            {
                return await Result<IList<BatchtypeEntity>>.FailureAsync(e.Message);
            }
        }

    }

}

using AutoMapper;
using Gas.Domain.Entity.PublicManagement;
using Gas.Services.PublicManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.TrucktypeFeatures.QueryHandler
{
    public record GetTrucktypeQuery() : IRequest<Result<IList<TrucktypeEntity>>>;

    internal class GetTrucktypeQueryHandler : IRequestHandler<GetTrucktypeQuery, Result<IList<TrucktypeEntity>>>
    {
        
        public async Task<Result<IList<TrucktypeEntity>>> Handle(GetTrucktypeQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new TrucktypeService().GetTrucktype();
                if (resp.Count>0)
                {
                    return await Result<IList<TrucktypeEntity>>.SuccessAsync(resp);
                }
                else
                {
                    return await Result<IList<TrucktypeEntity>>.FailureAsync("No Data Available");
                }
            }
            catch (Exception e)
            {
                return await Result<IList<TrucktypeEntity>>.FailureAsync(e.Message);
            }
        }

    }

}

using AutoMapper;
using Gas.Domain.Entity.PublicManagement;
using Gas.Services.PublicManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.WardFeatures.QueryHandler
{
    public record GetWardQuery() : IRequest<Result<IList<WardEntity>>>;

    internal class GetWardQueryHandler : IRequestHandler<GetWardQuery, Result<IList<WardEntity>>>
    {
        public async Task<Result<IList<WardEntity>>> Handle(GetWardQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new WardService().GetWard();
                if (resp.Count>0)
                {
                    return await Result<IList<WardEntity>>.SuccessAsync(resp);
                }
                else
                {
                    return await Result<IList<WardEntity>>.FailureAsync("No Data Available");
                }
            }
            catch (Exception e)
            {
                return await Result<IList<WardEntity>>.FailureAsync(e.Message);
            }
        }

    }

}

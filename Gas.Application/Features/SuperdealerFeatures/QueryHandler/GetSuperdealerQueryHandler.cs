using AutoMapper;
using Gas.Domain.Entity.PublicManagement;
using Gas.Services.PublicManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.SuperdealerFeatures.QueryHandler
{
    public record GetSuperdealerQuery() : IRequest<Result<IList<SuperdealerEntity>>>;

    internal class GetSuperdealerQueryHandler : IRequestHandler<GetSuperdealerQuery, Result<IList<SuperdealerEntity>>>
    {
        
        public async Task<Result<IList<SuperdealerEntity>>> Handle(GetSuperdealerQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new SuperdealerService().GetSuperdealer();
                if (resp.Count>0)
                {
                    return await Result<IList<SuperdealerEntity>>.SuccessAsync(resp);
                }
                else
                {
                    return await Result<IList<SuperdealerEntity>>.FailureAsync("No Data Available");
                }
            }
            catch (Exception e)
            {
                return await Result<IList<SuperdealerEntity>>.FailureAsync(e.Message);
            }
        }

    }

}

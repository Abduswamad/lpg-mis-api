using AutoMapper;
using MediatR;
using Gas.Domain.Entities;
using Gas.Utils;
using Gas.Domain.Entity.PublicManagement;
using Gas.Services.PublicManagement;
using Gas.Model.PublicManagement;

namespace Gas.Application.Features.SuperdealerFeatures.QueryHandler
{
    public record GetSuperdealerByModalQuery(GetSuperdealerModel? rqModel) : IRequest<Result<IList<SuperdealerEntity>>>;

    internal class GetSuperdealerByModalQueryHandler : IRequestHandler<GetSuperdealerByModalQuery, Result<IList<SuperdealerEntity>>>
    {
        public async Task<Result<IList<SuperdealerEntity>>> Handle(GetSuperdealerByModalQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new SuperdealerService().GetSuperdealer(request.rqModel);
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

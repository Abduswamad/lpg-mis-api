using AutoMapper;
using MediatR;
using Gas.Domain.Entities;
using Gas.Utils;
using Gas.Domain.Entity.PublicManagement;
using Gas.Services.PublicManagement;
using Gas.Model.PublicManagement;

namespace Gas.Application.Features.WardFeatures.QueryHandler
{
    public record GetWardByModalQuery(GetWardModel? rqModel) : IRequest<Result<IList<WardEntity>>>;

    internal class GetWardByModalQueryHandler : IRequestHandler<GetWardByModalQuery, Result<IList<WardEntity>>>
    {
        public async Task<Result<IList<WardEntity>>> Handle(GetWardByModalQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new WardService().GetWard(request.rqModel);
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

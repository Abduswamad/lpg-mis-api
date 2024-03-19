using AutoMapper;
using MediatR;
using Gas.Domain.Entities;
using Gas.Utils;
using Gas.Domain.Entity.PublicManagement;
using Gas.Services.PublicManagement;
using Gas.Model.PublicManagement;

namespace Gas.Application.Features.CommonstreetFeatures.QueryHandler
{
    public record GetCommonstreetByModalQuery(GetCommonstreetModel? rqModel) : IRequest<Result<IList<CommonstreetEntity>>>;

    internal class GetCommonstreetByModalQueryHandler : IRequestHandler<GetCommonstreetByModalQuery, Result<IList<CommonstreetEntity>>>
    {
        public async Task<Result<IList<CommonstreetEntity>>> Handle(GetCommonstreetByModalQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new CommonstreetService().GetCommonstreet(request.rqModel);
                if (resp.Count>0)
                {
                    return await Result<IList<CommonstreetEntity>>.SuccessAsync(resp);
                }
                else
                {
                    return await Result<IList<CommonstreetEntity>>.FailureAsync("No Data Available");
                }
            }
            catch (Exception e)
            {
                return await Result<IList<CommonstreetEntity>>.FailureAsync(e.Message);
            }
        }

    }

}

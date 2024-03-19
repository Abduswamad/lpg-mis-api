using AutoMapper;
using Gas.Domain.Entity.CompanyManagement;
using Gas.Services.CompanyManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.CylinderFeatures.QueryHandler
{
    public record GetCylinderQuery() : IRequest<Result<IList<CylinderEntity>>>;

    internal class GetCylinderQueryHandler : IRequestHandler<GetCylinderQuery, Result<IList<CylinderEntity>>>
    {
        public async Task<Result<IList<CylinderEntity>>> Handle(GetCylinderQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new CylinderService().GetCylinder();
                if (resp.Count>0)
                {
                    return await Result<IList<CylinderEntity>>.SuccessAsync(resp);
                }
                else
                {
                    return await Result<IList<CylinderEntity>>.FailureAsync("No Data Available");
                }
            }
            catch (Exception e)
            {
                return await Result<IList<CylinderEntity>>.FailureAsync(e.Message);
            }
        }

    }

}

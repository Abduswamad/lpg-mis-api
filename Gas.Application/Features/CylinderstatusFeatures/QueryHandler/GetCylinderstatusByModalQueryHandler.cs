using AutoMapper;
using MediatR;
using Gas.Domain.Entities;
using Gas.Utils;
using Gas.Domain.Entity.StoreManagement;
using Gas.Services.StoreManagement;
using Gas.Model.StoreManagement;

namespace Gas.Application.Features.CylinderstatusFeatures.QueryHandler
{
    public record GetCylinderstatusByModalQuery(GetCylinderstatusModel? rqModel) : IRequest<Result<IList<CylinderstatusEntity>>>;

    internal class GetCylinderstatusByModalQueryHandler : IRequestHandler<GetCylinderstatusByModalQuery, Result<IList<CylinderstatusEntity>>>
    {
        private readonly IMapper _mapper;
        public GetCylinderstatusByModalQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<IList<CylinderstatusEntity>>> Handle(GetCylinderstatusByModalQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new CylinderstatusService().GetCylinderstatus(request.rqModel);
                if (resp.Count>0)
                {
                    return await Result<IList<CylinderstatusEntity>>.SuccessAsync(resp);
                }
                else
                {
                    return await Result<IList<CylinderstatusEntity>>.FailureAsync("No Data Available");
                }
            }
            catch (Exception e)
            {
                return await Result<IList<CylinderstatusEntity>>.FailureAsync(e.Message);
            }
        }

    }

}

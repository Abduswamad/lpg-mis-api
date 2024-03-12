using AutoMapper;
using MediatR;
using Gas.Domain.Entities;
using Gas.Utils;
using Gas.Domain.Entity.CompanyManagement;
using Gas.Services.CompanyManagement;
using Gas.Model.CompanyManagement;

namespace Gas.Application.Features.CylinderFeatures.QueryHandler
{
    public record GetCylinderByModalQuery(GetCylinderModel? rqModel) : IRequest<Result<IList<CylinderEntity>>>;

    internal class GetCylinderByModalQueryHandler : IRequestHandler<GetCylinderByModalQuery, Result<IList<CylinderEntity>>>
    {
        private readonly IMapper _mapper;
        public GetCylinderByModalQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<IList<CylinderEntity>>> Handle(GetCylinderByModalQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new CylinderService().GetCylinder(request.rqModel);
                if (resp.Count>0)
                {
                    var response = _mapper.Map<List<CylinderEntity>>(resp);
                    return await Result<IList<CylinderEntity>>.SuccessAsync(response);
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

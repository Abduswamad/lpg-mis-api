using AutoMapper;
using MediatR;
using Gas.Domain.Entities;
using Gas.Utils;
using Gas.Domain.Entity.PublicManagement;
using Gas.Services.PublicManagement;
using Gas.Model.PublicManagement;

namespace Gas.Application.Features.CylindercompanyFeatures.QueryHandler
{
    public record GetCylindercompanyByModalQuery(GetCylindercompanyModel? rqModel) : IRequest<Result<IList<CylindercompanyEntity>>>;

    internal class GetCylindercompanyByModalQueryHandler : IRequestHandler<GetCylindercompanyByModalQuery, Result<IList<CylindercompanyEntity>>>
    {
        private readonly IMapper _mapper;
        public GetCylindercompanyByModalQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<IList<CylindercompanyEntity>>> Handle(GetCylindercompanyByModalQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new CylindercompanyService().GetCylindercompany(request.rqModel);
                if (resp.Count>0)
                {
                    var response = _mapper.Map<List<CylindercompanyEntity>>(resp);
                    return await Result<IList<CylindercompanyEntity>>.SuccessAsync(response);
                }
                else
                {
                    return await Result<IList<CylindercompanyEntity>>.FailureAsync("No Data Available");
                }
            }
            catch (Exception e)
            {
                return await Result<IList<CylindercompanyEntity>>.FailureAsync(e.Message);
            }
        }

    }

}

using AutoMapper;
using Gas.Domain.Entity.PublicManagement;
using Gas.Services.PublicManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.CylindercompanyFeatures.QueryHandler
{
    public record GetCylindercompanyQuery() : IRequest<Result<IList<CylindercompanyEntity>>>;

    internal class GetCylindercompanyQueryHandler : IRequestHandler<GetCylindercompanyQuery, Result<IList<CylindercompanyEntity>>>
    {
        private readonly IMapper _mapper;
        public GetCylindercompanyQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<IList<CylindercompanyEntity>>> Handle(GetCylindercompanyQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new CylindercompanyService().GetCylindercompany();
                if (resp.Count>0)
                {
                    return await Result<IList<CylindercompanyEntity>>.SuccessAsync(resp);
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

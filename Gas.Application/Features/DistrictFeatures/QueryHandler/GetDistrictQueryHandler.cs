using AutoMapper;
using Gas.Domain.Entity.PublicManagement;
using Gas.Services.PublicManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.DistrictFeatures.QueryHandler
{
    public record GetDistrictQuery() : IRequest<Result<IList<DistrictEntity>>>;

    internal class GetDistrictQueryHandler : IRequestHandler<GetDistrictQuery, Result<IList<DistrictEntity>>>
    {
        private readonly IMapper _mapper;
        public GetDistrictQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<IList<DistrictEntity>>> Handle(GetDistrictQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new DistrictService().GetDistrict();
                if (resp.Count>0)
                {
                    return await Result<IList<DistrictEntity>>.SuccessAsync(resp);
                }
                else
                {
                    return await Result<IList<DistrictEntity>>.FailureAsync("No Data Available");
                }
            }
            catch (Exception e)
            {
                return await Result<IList<DistrictEntity>>.FailureAsync(e.Message);
            }
        }

    }

}

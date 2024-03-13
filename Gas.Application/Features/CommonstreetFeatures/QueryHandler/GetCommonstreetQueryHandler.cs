using AutoMapper;
using Gas.Domain.Entity.PublicManagement;
using Gas.Services.PublicManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.CommonstreetFeatures.QueryHandler
{
    public record GetCommonstreetQuery() : IRequest<Result<IList<CommonstreetEntity>>>;

    internal class GetCommonstreetQueryHandler : IRequestHandler<GetCommonstreetQuery, Result<IList<CommonstreetEntity>>>
    {
        private readonly IMapper _mapper;
        public GetCommonstreetQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<IList<CommonstreetEntity>>> Handle(GetCommonstreetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new CommonstreetService().GetCommonstreet();
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

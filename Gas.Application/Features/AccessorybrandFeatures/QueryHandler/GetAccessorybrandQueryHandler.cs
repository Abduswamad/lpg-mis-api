using AutoMapper;
using Gas.Domain.Entity.PublicManagement;
using Gas.Services.PublicManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.AccessorybrandFeatures.QueryHandler
{
    public record GetAccessorybrandQuery() : IRequest<Result<IList<AccessorybrandEntity>>>;

    internal class GetAccessorybrandQueryHandler : IRequestHandler<GetAccessorybrandQuery, Result<IList<AccessorybrandEntity>>>
    {
        private readonly IMapper _mapper;
        public GetAccessorybrandQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<IList<AccessorybrandEntity>>> Handle(GetAccessorybrandQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new AccessorybrandService().GetAccessorybrand();
                if (resp.Count>0)
                {
                    return await Result<IList<AccessorybrandEntity>>.SuccessAsync(resp);
                }
                else
                {
                    return await Result<IList<AccessorybrandEntity>>.FailureAsync("No Data Available");
                }
            }
            catch (Exception e)
            {
                return await Result<IList<AccessorybrandEntity>>.FailureAsync(e.Message);
            }
        }

    }

}

using AutoMapper;
using Gas.Domain.Entity.CompanyManagement;
using Gas.Services.CompanyManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.DepoFeatures.QueryHandler
{
    public record GetDepoQuery() : IRequest<Result<IList<DepoEntity>>>;

    internal class GetDepoQueryHandler : IRequestHandler<GetDepoQuery, Result<IList<DepoEntity>>>
    {
        private readonly IMapper _mapper;
        public GetDepoQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<IList<DepoEntity>>> Handle(GetDepoQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new DepoService().GetDepo();
                if (resp.Count>0)
                {
                    return await Result<IList<DepoEntity>>.SuccessAsync(resp);
                }
                else
                {
                    return await Result<IList<DepoEntity>>.FailureAsync("No Data Available");
                }
            }
            catch (Exception e)
            {
                return await Result<IList<DepoEntity>>.FailureAsync(e.Message);
            }
        }

    }

}

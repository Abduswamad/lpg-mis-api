using AutoMapper;
using MediatR;
using Gas.Domain.Entities;
using Gas.Utils;
using Gas.Domain.Entity.CompanyManagement;
using Gas.Services.CompanyManagement;
using Gas.Model.CompanyManagement;

namespace Gas.Application.Features.DepoFeatures.QueryHandler
{
    public record GetDepoByModalQuery(GetDepoModel? rqModel) : IRequest<Result<IList<DepoEntity>>>;

    internal class GetDepoByModalQueryHandler : IRequestHandler<GetDepoByModalQuery, Result<IList<DepoEntity>>>
    {
        private readonly IMapper _mapper;
        public GetDepoByModalQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<IList<DepoEntity>>> Handle(GetDepoByModalQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new DepoService().GetDepo(request.rqModel);
                if (resp.Count>0)
                {
                    var response = _mapper.Map<List<DepoEntity>>(resp);
                    return await Result<IList<DepoEntity>>.SuccessAsync(response);
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

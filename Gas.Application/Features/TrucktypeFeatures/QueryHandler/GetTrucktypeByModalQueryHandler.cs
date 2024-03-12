using AutoMapper;
using MediatR;
using Gas.Domain.Entities;
using Gas.Utils;
using Gas.Domain.Entity.PublicManagement;
using Gas.Services.PublicManagement;
using Gas.Model.PublicManagement;

namespace Gas.Application.Features.TrucktypeFeatures.QueryHandler
{
    public record GetTrucktypeByModalQuery(GetTrucktypeModel? rqModel) : IRequest<Result<IList<TrucktypeEntity>>>;

    internal class GetTrucktypeByModalQueryHandler : IRequestHandler<GetTrucktypeByModalQuery, Result<IList<TrucktypeEntity>>>
    {
        private readonly IMapper _mapper;
        public GetTrucktypeByModalQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<IList<TrucktypeEntity>>> Handle(GetTrucktypeByModalQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new TrucktypeService().GetTrucktype(request.rqModel);
                if (resp.Count>0)
                {
                    var response = _mapper.Map<List<TrucktypeEntity>>(resp);
                    return await Result<IList<TrucktypeEntity>>.SuccessAsync(response);
                }
                else
                {
                    return await Result<IList<TrucktypeEntity>>.FailureAsync("No Data Available");
                }
            }
            catch (Exception e)
            {
                return await Result<IList<TrucktypeEntity>>.FailureAsync(e.Message);
            }
        }

    }

}

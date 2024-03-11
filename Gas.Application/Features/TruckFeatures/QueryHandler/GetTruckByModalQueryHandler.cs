using AutoMapper;
using MediatR;
using Gas.Domain.Entities;
using Gas.Utils;
using Gas.Domain.Entity.CompanyManagement;
using Gas.Services.CompanyManagement;
using Gas.Model.CompanyManagement;

namespace Gas.Application.Features.TruckFeatures.QueryHandler
{
    public record GetTruckByModalQuery(GetTruckModel? rqModel) : IRequest<Result<IList<TruckEntity>>>;

    internal class GetTruckByModalQueryHandler : IRequestHandler<GetTruckByModalQuery, Result<IList<TruckEntity>>>
    {
        private readonly IMapper _mapper;
        public GetTruckByModalQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<IList<TruckEntity>>> Handle(GetTruckByModalQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new TruckService().GetTruck(request.rqModel);
                if (resp.Count>0)
                {
                    var response = _mapper.Map<List<TruckEntity>>(resp);
                    return await Result<IList<TruckEntity>>.SuccessAsync(response);
                }
                else
                {
                    return await Result<IList<TruckEntity>>.FailureAsync("No Data Available");
                }
            }
            catch (Exception e)
            {
                return await Result<IList<TruckEntity>>.FailureAsync(e.Message);
            }
        }

    }

}

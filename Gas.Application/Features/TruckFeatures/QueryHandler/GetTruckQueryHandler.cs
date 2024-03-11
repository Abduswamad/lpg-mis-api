using AutoMapper;
using Gas.Domain.Entity.CompanyManagement;
using Gas.Services.CompanyManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.TruckFeatures.QueryHandler
{
    public record GetTruckQuery() : IRequest<Result<IList<TruckEntity>>>;

    internal class GetTruckQueryHandler : IRequestHandler<GetTruckQuery, Result<IList<TruckEntity>>>
    {
        private readonly IMapper _mapper;
        public GetTruckQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<IList<TruckEntity>>> Handle(GetTruckQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new TruckService().GetAllTruck();
                if (resp.Count>0)
                {
                    return await Result<IList<TruckEntity>>.SuccessAsync(resp);
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

using AutoMapper;
using Gas.Domain.Entity.CompanyManagement;
using Gas.Services.CompanyManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.AccessoryFeatures.QueryHandler
{
    public record GetAccessoryQuery() : IRequest<Result<IList<AccessoryEntity>>>;

    internal class GetAccessoryQueryHandler : IRequestHandler<GetAccessoryQuery, Result<IList<AccessoryEntity>>>
    {
        private readonly IMapper _mapper;
        public GetAccessoryQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<IList<AccessoryEntity>>> Handle(GetAccessoryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new AccessoryService().GetAccessory();
                if (resp.Count>0)
                {
                    return await Result<IList<AccessoryEntity>>.SuccessAsync(resp);
                }
                else
                {
                    return await Result<IList<AccessoryEntity>>.FailureAsync("No Data Available");
                }
            }
            catch (Exception e)
            {
                return await Result<IList<AccessoryEntity>>.FailureAsync(e.Message);
            }
        }

    }

}

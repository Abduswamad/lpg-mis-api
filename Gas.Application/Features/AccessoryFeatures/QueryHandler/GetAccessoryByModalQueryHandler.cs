using AutoMapper;
using MediatR;
using Gas.Domain.Entities;
using Gas.Utils;
using Gas.Domain.Entity.CompanyManagement;
using Gas.Services.CompanyManagement;
using Gas.Model.CompanyManagement;

namespace Gas.Application.Features.AccessoryFeatures.QueryHandler
{
    public record GetAccessoryByModalQuery(GetAccessoryModel? rqModel) : IRequest<Result<IList<AccessoryEntity>>>;

    internal class GetAccessoryByModalQueryHandler : IRequestHandler<GetAccessoryByModalQuery, Result<IList<AccessoryEntity>>>
    {
        private readonly IMapper _mapper;
        public GetAccessoryByModalQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<IList<AccessoryEntity>>> Handle(GetAccessoryByModalQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new AccessoryService().GetAccessory(request.rqModel);
                if (resp.Count>0)
                {
                    var response = _mapper.Map<List<AccessoryEntity>>(resp);
                    return await Result<IList<AccessoryEntity>>.SuccessAsync(response);
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

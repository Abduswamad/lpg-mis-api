using AutoMapper;
using MediatR;
using Gas.Domain.Entities;
using Gas.Utils;
using Gas.Domain.Entity.CompanyManagement;
using Gas.Services.CompanyManagement;
using Gas.Model.CompanyManagement;

namespace Gas.Application.Features.ShopFeatures.QueryHandler
{
    public record GetShopByModalQuery(GetShopModel? rqModel) : IRequest<Result<IList<ShopEntity>>>;

    internal class GetShopByModalQueryHandler : IRequestHandler<GetShopByModalQuery, Result<IList<ShopEntity>>>
    {
        private readonly IMapper _mapper;
        public GetShopByModalQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<IList<ShopEntity>>> Handle(GetShopByModalQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new ShopService().GetShop(request.rqModel);
                if (resp.Count>0)
                {
                    var response = _mapper.Map<List<ShopEntity>>(resp);
                    return await Result<IList<ShopEntity>>.SuccessAsync(response);
                }
                else
                {
                    return await Result<IList<ShopEntity>>.FailureAsync("No Data Available");
                }
            }
            catch (Exception e)
            {
                return await Result<IList<ShopEntity>>.FailureAsync(e.Message);
            }
        }

    }

}

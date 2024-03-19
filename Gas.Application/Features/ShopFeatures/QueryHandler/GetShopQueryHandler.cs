using AutoMapper;
using Gas.Domain.Entity.CompanyManagement;
using Gas.Services.CompanyManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.ShopFeatures.QueryHandler
{
    public record GetShopQuery() : IRequest<Result<IList<ShopEntity>>>;

    internal class GetShopQueryHandler : IRequestHandler<GetShopQuery, Result<IList<ShopEntity>>>
    {
        public async Task<Result<IList<ShopEntity>>> Handle(GetShopQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new ShopService().GetShop();
                if (resp.Count>0)
                {
                    return await Result<IList<ShopEntity>>.SuccessAsync(resp);
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

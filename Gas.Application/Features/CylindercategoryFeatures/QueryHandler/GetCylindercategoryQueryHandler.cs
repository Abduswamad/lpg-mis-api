using AutoMapper;
using Gas.Domain.Entity.PublicManagement;
using Gas.Services.PublicManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.CylindercategoryFeatures.QueryHandler
{
    public record GetCylindercategoryQuery() : IRequest<Result<IList<CylindercategoryEntity>>>;

    internal class GetCylindercategoryQueryHandler : IRequestHandler<GetCylindercategoryQuery, Result<IList<CylindercategoryEntity>>>
    {
        
        public async Task<Result<IList<CylindercategoryEntity>>> Handle(GetCylindercategoryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new CylindercategoryService().GetCylindercategory();
                if (resp.Count>0)
                {
                    return await Result<IList<CylindercategoryEntity>>.SuccessAsync(resp);
                }
                else
                {
                    return await Result<IList<CylindercategoryEntity>>.FailureAsync("No Data Available");
                }
            }
            catch (Exception e)
            {
                return await Result<IList<CylindercategoryEntity>>.FailureAsync(e.Message);
            }
        }

    }

}

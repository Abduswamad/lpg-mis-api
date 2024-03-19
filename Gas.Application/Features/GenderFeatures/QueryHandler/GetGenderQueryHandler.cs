using AutoMapper;
using Gas.Domain.Entity.PublicManagement;
using Gas.Services.PublicManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.GenderFeatures.QueryHandler
{
    public record GetGenderQuery() : IRequest<Result<IList<GenderEntity>>>;

    internal class GetGenderQueryHandler : IRequestHandler<GetGenderQuery, Result<IList<GenderEntity>>>
    {
        public async Task<Result<IList<GenderEntity>>> Handle(GetGenderQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new GenderService().GetGender();
                if (resp.Count>0)
                {
                    return await Result<IList<GenderEntity>>.SuccessAsync(resp);
                }
                else
                {
                    return await Result<IList<GenderEntity>>.FailureAsync("No Data Available");
                }
            }
            catch (Exception e)
            {
                return await Result<IList<GenderEntity>>.FailureAsync(e.Message);
            }
        }

    }

}

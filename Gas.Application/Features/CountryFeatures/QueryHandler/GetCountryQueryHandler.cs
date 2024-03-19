using AutoMapper;
using Gas.Domain.Entity.PublicManagement;
using Gas.Services.PublicManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.CountryFeatures.QueryHandler
{
    public record GetCountryQuery() : IRequest<Result<IList<CountryEntity>>>;

    internal class GetCountryQueryHandler : IRequestHandler<GetCountryQuery, Result<IList<CountryEntity>>>
    {
        public async Task<Result<IList<CountryEntity>>> Handle(GetCountryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new CountryService().GetCountry();
                if (resp.Count>0)
                {
                    return await Result<IList<CountryEntity>>.SuccessAsync(resp);
                }
                else
                {
                    return await Result<IList<CountryEntity>>.FailureAsync("No Data Available");
                }
            }
            catch (Exception e)
            {
                return await Result<IList<CountryEntity>>.FailureAsync(e.Message);
            }
        }

    }

}

﻿using AutoMapper;
using MediatR;
using Gas.Domain.Entities;
using Gas.Utils;
using Gas.Domain.Entity.PublicManagement;
using Gas.Services.PublicManagement;
using Gas.Model.PublicManagement;

namespace Gas.Application.Features.CountryFeatures.QueryHandler
{
    public record GetCountryByModalQuery(GetCountryModel? rqModel) : IRequest<Result<IList<CountryEntity>>>;

    internal class GetCountryByModalQueryHandler : IRequestHandler<GetCountryByModalQuery, Result<IList<CountryEntity>>>
    {
        private readonly IMapper _mapper;
        public GetCountryByModalQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<IList<CountryEntity>>> Handle(GetCountryByModalQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new CountryService().GetCountry(request.rqModel);
                if (resp.Count>0)
                {
                    var response = _mapper.Map<List<CountryEntity>>(resp);
                    return await Result<IList<CountryEntity>>.SuccessAsync(response);
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

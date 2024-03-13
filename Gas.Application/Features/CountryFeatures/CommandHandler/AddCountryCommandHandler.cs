using AutoMapper;
using Gas.Domain.Entities;
using Gas.Model.PublicManagement;
using Gas.Services.PublicManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.CountryFeatures.CommandHandler
{
    public record AddCountryCommand(AddCountryModel Request) : IRequest<Result<QueryResEntity>>;

    internal class AddCountryCommandHandler : IRequestHandler<AddCountryCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public AddCountryCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(AddCountryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var req = _mapper.Map<InsCountryModel>(request.Request);
                var resp = new CountryService().AddCountry(req);
                if (resp.Code == 200)
                {                    
                    return await Result<QueryResEntity>.SuccessAsync(resp, resp.Msg);
                }
                else
                {
                    return await Result<QueryResEntity>.FailureAsync(resp.Msg);
                }

            }
            catch (Exception e)
            {
                return await Result<QueryResEntity>.FailureAsync(e.Message);
            }
        }

    }

}

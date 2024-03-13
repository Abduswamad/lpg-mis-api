using AutoMapper;
using FluentValidation;
using Gas.Domain.Entities;
using Gas.Model.PublicManagement;
using Gas.Services.PublicManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.CountryFeatures.CommandHandler
{
    public record UpdateCountryStatusCommand(RequestCountryStatusModel Request) : IRequest<Result<QueryResEntity>>;

    internal class UpdateCountryStatusCommandHandler : IRequestHandler<UpdateCountryStatusCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public UpdateCountryStatusCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(UpdateCountryStatusCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new CountryService().UpdateStatusCountry(request.Request);
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

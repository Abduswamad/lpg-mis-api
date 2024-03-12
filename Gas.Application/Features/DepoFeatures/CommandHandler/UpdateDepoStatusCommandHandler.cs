using AutoMapper;
using FluentValidation;
using Gas.Domain.Entities;
using Gas.Model.CompanyManagement;
using Gas.Services.CompanyManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.DepoFeatures.CommandHandler
{
    public record UpdateDepoStatusCommand(RequestDepoStatusModel Request) : IRequest<Result<QueryResEntity>>;

    internal class UpdateDepoStatusCommandHandler : IRequestHandler<UpdateDepoStatusCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public UpdateDepoStatusCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(UpdateDepoStatusCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new DepoService().UpdateStatusDepo(request.Request);
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

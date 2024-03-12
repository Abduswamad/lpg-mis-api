using AutoMapper;
using FluentValidation;
using Gas.Domain.Entities;
using Gas.Model.PublicManagement;
using Gas.Services.PublicManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.TrucktypeFeatures.CommandHandler
{
    public record UpdateTrucktypeStatusCommand(RequestTrucktypeStatusModel Request) : IRequest<Result<QueryResEntity>>;

    internal class UpdateTrucktypeStatusCommandHandler : IRequestHandler<UpdateTrucktypeStatusCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public UpdateTrucktypeStatusCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(UpdateTrucktypeStatusCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new TrucktypeService().UpdateStatusTrucktype(request.Request);
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

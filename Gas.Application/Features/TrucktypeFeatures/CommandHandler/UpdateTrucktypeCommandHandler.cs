using AutoMapper;
using FluentValidation;
using Gas.Domain.Entities;
using Gas.Model.PublicManagement;
using Gas.Services.PublicManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.TrucktypeFeatures.CommandHandler
{
    public record UpdateTrucktypeCommand(UpdateTrucktypeModel Request) : IRequest<Result<QueryResEntity>>;

    internal class UpdateTrucktypeCommandHandler : IRequestHandler<UpdateTrucktypeCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public UpdateTrucktypeCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(UpdateTrucktypeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new TrucktypeService().UpdateTrucktype(request.Request);
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

using AutoMapper;
using FluentValidation;
using Gas.Domain.Entities;
using Gas.Model.PublicManagement;
using Gas.Services.PublicManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.WardFeatures.CommandHandler
{
    public record UpdateWardStatusCommand(RequestWardStatusModel Request) : IRequest<Result<QueryResEntity>>;

    internal class UpdateWardStatusCommandHandler : IRequestHandler<UpdateWardStatusCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public UpdateWardStatusCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(UpdateWardStatusCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new WardService().UpdateStatusWard(request.Request);
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

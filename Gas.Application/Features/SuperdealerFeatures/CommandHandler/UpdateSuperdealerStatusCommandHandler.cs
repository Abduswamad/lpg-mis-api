using AutoMapper;
using FluentValidation;
using Gas.Domain.Entities;
using Gas.Model.PublicManagement;
using Gas.Services.PublicManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.SuperdealerFeatures.CommandHandler
{
    public record UpdateSuperdealerStatusCommand(RequestSuperdealerStatusModel Request) : IRequest<Result<QueryResEntity>>;

    internal class UpdateSuperdealerStatusCommandHandler : IRequestHandler<UpdateSuperdealerStatusCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public UpdateSuperdealerStatusCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(UpdateSuperdealerStatusCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new SuperdealerService().UpdateStatusSuperdealer(request.Request);
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

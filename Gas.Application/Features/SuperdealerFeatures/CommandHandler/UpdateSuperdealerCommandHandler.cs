using AutoMapper;
using FluentValidation;
using Gas.Domain.Entities;
using Gas.Model.PublicManagement;
using Gas.Services.PublicManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.SuperdealerFeatures.CommandHandler
{
    public record UpdateSuperdealerCommand(UpdateSuperdealerModel Request) : IRequest<Result<QueryResEntity>>;

    internal class UpdateSuperdealerCommandHandler : IRequestHandler<UpdateSuperdealerCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public UpdateSuperdealerCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(UpdateSuperdealerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new SuperdealerService().UpdateSuperdealer(request.Request);
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

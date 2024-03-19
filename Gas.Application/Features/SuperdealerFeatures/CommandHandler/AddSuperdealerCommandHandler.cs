using AutoMapper;
using Gas.Domain.Entities;
using Gas.Model.PublicManagement;
using Gas.Services.PublicManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.SuperdealerFeatures.CommandHandler
{
    public record AddSuperdealerCommand(AddSuperdealerModel Request) : IRequest<Result<QueryResEntity>>;

    internal class AddSuperdealerCommandHandler : IRequestHandler<AddSuperdealerCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public AddSuperdealerCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(AddSuperdealerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var req = _mapper.Map<InsSuperdealerModel>(request.Request);
                var resp = new SuperdealerService().AddSuperdealer(req);
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

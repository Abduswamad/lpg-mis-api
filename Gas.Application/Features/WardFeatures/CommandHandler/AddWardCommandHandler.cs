using AutoMapper;
using Gas.Domain.Entities;
using Gas.Model.PublicManagement;
using Gas.Services.PublicManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.WardFeatures.CommandHandler
{
    public record AddWardCommand(AddWardModel Request) : IRequest<Result<QueryResEntity>>;

    internal class AddWardCommandHandler : IRequestHandler<AddWardCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public AddWardCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(AddWardCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var req = _mapper.Map<InsWardModel>(request.Request);
                var resp = new WardService().AddWard(req);
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

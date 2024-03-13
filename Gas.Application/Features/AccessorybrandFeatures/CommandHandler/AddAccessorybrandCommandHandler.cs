using AutoMapper;
using Gas.Domain.Entities;
using Gas.Model.PublicManagement;
using Gas.Services.PublicManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.AccessorybrandFeatures.CommandHandler
{
    public record AddAccessorybrandCommand(AddAccessorybrandModel Request) : IRequest<Result<QueryResEntity>>;

    internal class AddAccessorybrandCommandHandler : IRequestHandler<AddAccessorybrandCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public AddAccessorybrandCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(AddAccessorybrandCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var req = _mapper.Map<InsAccessorybrandModel>(request.Request);
                var resp = new AccessorybrandService().AddAccessorybrand(req);
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

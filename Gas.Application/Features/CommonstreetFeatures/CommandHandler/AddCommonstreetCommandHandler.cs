using AutoMapper;
using Gas.Domain.Entities;
using Gas.Model.PublicManagement;
using Gas.Services.PublicManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.CommonstreetFeatures.CommandHandler
{
    public record AddCommonstreetCommand(AddCommonstreetModel Request) : IRequest<Result<QueryResEntity>>;

    internal class AddCommonstreetCommandHandler : IRequestHandler<AddCommonstreetCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public AddCommonstreetCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(AddCommonstreetCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var req = _mapper.Map<InsCommonstreetModel>(request.Request);
                var resp = new CommonstreetService().AddCommonstreet(req);
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

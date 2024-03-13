using AutoMapper;
using Gas.Domain.Entities;
using Gas.Model.PublicManagement;
using Gas.Services.PublicManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.RegionFeatures.CommandHandler
{
    public record AddRegionCommand(AddRegionModel Request) : IRequest<Result<QueryResEntity>>;

    internal class AddRegionCommandHandler : IRequestHandler<AddRegionCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public AddRegionCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(AddRegionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var req = _mapper.Map<InsRegionModel>(request.Request);
                var resp = new RegionService().AddRegion(req);
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

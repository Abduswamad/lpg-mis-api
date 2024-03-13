using AutoMapper;
using FluentValidation;
using Gas.Domain.Entities;
using Gas.Model.PublicManagement;
using Gas.Services.PublicManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.RegionFeatures.CommandHandler
{
    public record UpdateRegionCommand(UpdateRegionModel Request) : IRequest<Result<QueryResEntity>>;

    internal class UpdateRegionCommandHandler : IRequestHandler<UpdateRegionCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public UpdateRegionCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(UpdateRegionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new RegionService().UpdateRegion(request.Request);
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

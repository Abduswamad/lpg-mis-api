using AutoMapper;
using FluentValidation;
using Gas.Domain.Entities;
using Gas.Model.PublicManagement;
using Gas.Services.PublicManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.DistrictFeatures.CommandHandler
{
    public record UpdateDistrictCommand(UpdateDistrictModel Request) : IRequest<Result<QueryResEntity>>;

    internal class UpdateDistrictCommandHandler : IRequestHandler<UpdateDistrictCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public UpdateDistrictCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(UpdateDistrictCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new DistrictService().UpdateDistrict(request.Request);
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

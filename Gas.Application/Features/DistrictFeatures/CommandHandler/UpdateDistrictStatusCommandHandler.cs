using AutoMapper;
using FluentValidation;
using Gas.Domain.Entities;
using Gas.Model.PublicManagement;
using Gas.Services.PublicManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.DistrictFeatures.CommandHandler
{
    public record UpdateDistrictStatusCommand(RequestDistrictStatusModel Request) : IRequest<Result<QueryResEntity>>;

    internal class UpdateDistrictStatusCommandHandler : IRequestHandler<UpdateDistrictStatusCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public UpdateDistrictStatusCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(UpdateDistrictStatusCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new DistrictService().UpdateStatusDistrict(request.Request);
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

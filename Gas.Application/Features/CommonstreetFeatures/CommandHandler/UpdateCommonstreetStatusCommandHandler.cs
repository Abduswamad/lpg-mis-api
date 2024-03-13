using AutoMapper;
using FluentValidation;
using Gas.Domain.Entities;
using Gas.Model.PublicManagement;
using Gas.Services.PublicManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.CommonstreetFeatures.CommandHandler
{
    public record UpdateCommonstreetStatusCommand(RequestCommonstreetStatusModel Request) : IRequest<Result<QueryResEntity>>;

    internal class UpdateCommonstreetStatusCommandHandler : IRequestHandler<UpdateCommonstreetStatusCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public UpdateCommonstreetStatusCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(UpdateCommonstreetStatusCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new CommonstreetService().UpdateStatusCommonstreet(request.Request);
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

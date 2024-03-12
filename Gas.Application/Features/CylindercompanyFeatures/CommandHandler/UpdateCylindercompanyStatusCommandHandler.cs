using AutoMapper;
using FluentValidation;
using Gas.Domain.Entities;
using Gas.Model.PublicManagement;
using Gas.Services.PublicManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.CylindercompanyFeatures.CommandHandler
{
    public record UpdateCylindercompanyStatusCommand(RequestCylindercompanyStatusModel Request) : IRequest<Result<QueryResEntity>>;

    internal class UpdateCylindercompanyStatusCommandHandler : IRequestHandler<UpdateCylindercompanyStatusCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public UpdateCylindercompanyStatusCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(UpdateCylindercompanyStatusCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new CylindercompanyService().UpdateStatusCylindercompany(request.Request);
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

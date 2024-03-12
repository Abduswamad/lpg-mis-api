using AutoMapper;
using FluentValidation;
using Gas.Domain.Entities;
using Gas.Model.PublicManagement;
using Gas.Services.PublicManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.CylindercompanyFeatures.CommandHandler
{
    public record UpdateCylindercompanyCommand(UpdateCylindercompanyModel Request) : IRequest<Result<QueryResEntity>>;

    internal class UpdateCylindercompanyCommandHandler : IRequestHandler<UpdateCylindercompanyCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public UpdateCylindercompanyCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(UpdateCylindercompanyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new CylindercompanyService().UpdateCylindercompany(request.Request);
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

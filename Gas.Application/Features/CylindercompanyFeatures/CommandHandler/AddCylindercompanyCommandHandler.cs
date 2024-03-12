using AutoMapper;
using Gas.Domain.Entities;
using Gas.Model.PublicManagement;
using Gas.Services.PublicManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.CylindercompanyFeatures.CommandHandler
{
    public record AddCylindercompanyCommand(AddCylindercompanyModel Request) : IRequest<Result<QueryResEntity>>;

    internal class AddCylindercompanyCommandHandler : IRequestHandler<AddCylindercompanyCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public AddCylindercompanyCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(AddCylindercompanyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var req = _mapper.Map<InsCylindercompanyModel>(request.Request);
                var resp = new CylindercompanyService().AddCylindercompany(req);
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

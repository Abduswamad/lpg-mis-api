using AutoMapper;
using FluentValidation;
using Gas.Domain.Entities;
using Gas.Model.CompanyManagement;
using Gas.Services.CompanyManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.RoleFeatures.CommandHandler
{
    public record AddRoleCommand(AddRoleModel Request) : IRequest<Result<QueryResEntity>>;

    internal class AddRoleCommandHandler : IRequestHandler<AddRoleCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public AddRoleCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var req = _mapper.Map<InsRoleModel>(request.Request);
                var resp = new RoleService().AddRole(req);
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

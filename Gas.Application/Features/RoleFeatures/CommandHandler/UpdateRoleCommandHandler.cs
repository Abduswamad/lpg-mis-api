using AutoMapper;
using FluentValidation;
using Gas.Domain.Entities;
using Gas.Model.CompanyManagement;
using Gas.Services.CompanyManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.RoleFeatures.CommandHandler
{
    public record UpdateRoleCommand(UpdateRoleModel Request) : IRequest<Result<QueryResEntity>>;

    internal class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public UpdateRoleCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new RoleService().UpdateRole(request.Request);
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

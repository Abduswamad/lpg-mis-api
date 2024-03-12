using AutoMapper;
using FluentValidation;
using Gas.Domain.Entities;
using Gas.Model.CompanyManagement;
using Gas.Services.CompanyManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.StaffroleFeatures.CommandHandler
{
    public record UpdateStaffroleCommand(UpdateStaffroleModel Request) : IRequest<Result<QueryResEntity>>;

    internal class UpdateStaffroleCommandHandler : IRequestHandler<UpdateStaffroleCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public UpdateStaffroleCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(UpdateStaffroleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new StaffroleService().UpdateStaffrole(request.Request);
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

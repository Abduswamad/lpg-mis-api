using AutoMapper;
using FluentValidation;
using Gas.Domain.Entities;
using Gas.Model.CompanyManagement;
using Gas.Services.CompanyManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.StaffroleFeatures.CommandHandler
{
    public record AddStaffroleCommand(AddStaffroleModel Request) : IRequest<Result<QueryResEntity>>;

    internal class AddStaffroleCommandHandler : IRequestHandler<AddStaffroleCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public AddStaffroleCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(AddStaffroleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new StaffroleService().AddStaffrole(request.Request);
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

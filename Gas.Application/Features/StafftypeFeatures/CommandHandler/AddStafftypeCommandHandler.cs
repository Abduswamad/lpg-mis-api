using AutoMapper;
using FluentValidation;
using Gas.Domain.Entities;
using Gas.Model.CompanyManagement;
using Gas.Services.CompanyManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.StafftypeFeatures.CommandHandler
{
    public record AddStafftypeCommand(AddStafftypeModel Request) : IRequest<Result<QueryResEntity>>;

    internal class AddStafftypeCommandHandler : IRequestHandler<AddStafftypeCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public AddStafftypeCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(AddStafftypeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var req = _mapper.Map<InsStafftypeModel>(request.Request);
                var resp = new StafftypeService().AddStafftype(req);
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

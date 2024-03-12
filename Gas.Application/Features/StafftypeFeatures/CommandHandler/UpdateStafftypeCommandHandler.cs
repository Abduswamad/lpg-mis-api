using AutoMapper;
using FluentValidation;
using Gas.Domain.Entities;
using Gas.Model.CompanyManagement;
using Gas.Services.CompanyManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.StafftypeFeatures.CommandHandler
{
    public record UpdateStafftypeCommand(UpdateStafftypeModel Request) : IRequest<Result<QueryResEntity>>;

    internal class UpdateStafftypeCommandHandler : IRequestHandler<UpdateStafftypeCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public UpdateStafftypeCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(UpdateStafftypeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new StafftypeService().UpdateStafftype(request.Request);
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

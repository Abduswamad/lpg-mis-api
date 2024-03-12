using AutoMapper;
using FluentValidation;
using Gas.Domain.Entities;
using Gas.Model.CompanyManagement;
using Gas.Services.CompanyManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.StafftypeFeatures.CommandHandler
{
    public record UpdateStafftypeStatusCommand(RequestStafftypeStatusModel Request) : IRequest<Result<QueryResEntity>>;

    internal class UpdateStafftypeStatusCommandHandler : IRequestHandler<UpdateStafftypeStatusCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public UpdateStafftypeStatusCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(UpdateStafftypeStatusCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new StafftypeService().UpdateStatusStafftype(request.Request);
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

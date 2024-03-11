using AutoMapper;
using FluentValidation;
using Gas.Domain.Entities;
using Gas.Model.CompanyManagement;
using Gas.Services.CompanyManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.StaffFeatures.CommandHandler
{
    public record UpdateStaffStatusCommand(RequestStaffStatusModel Request) : IRequest<Result<QueryResEntity>>;

    internal class UpdateStaffStatusCommandHandler : IRequestHandler<UpdateStaffStatusCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public UpdateStaffStatusCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(UpdateStaffStatusCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new StaffService().UpdateStatusStaff(request.Request);
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

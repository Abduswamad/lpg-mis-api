using AutoMapper;
using FluentValidation;
using Gas.Domain.Entities;
using Gas.Model.CompanyManagement;
using Gas.Services.CompanyManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.UserFeatures.CommandHandler
{
    public record StaffResetPasswordCommand(RequestStaffResetpassChangeModel Request) : IRequest<Result<QueryResEntity>>;

    internal class StaffResetPasswordCommandHandler : IRequestHandler<StaffResetPasswordCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public StaffResetPasswordCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(StaffResetPasswordCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new StaffService().StaffResetPassword(request.Request);
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

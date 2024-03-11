using AutoMapper;
using FluentValidation;
using Gas.Domain.Entities;
using Gas.Model.CompanyManagement;
using Gas.Services.CompanyManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.UserFeatures.CommandHandler
{
    public record StaffChangePasswordCommand(RequestStaffpassChangeModel Request) : IRequest<Result<QueryResEntity>>;

    internal class StaffChangePasswordCommandHandler : IRequestHandler<StaffChangePasswordCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public StaffChangePasswordCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(StaffChangePasswordCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new StaffService().StaffChangePassword(request.Request);
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

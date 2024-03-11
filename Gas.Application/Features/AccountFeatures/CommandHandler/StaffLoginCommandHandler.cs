using AutoMapper;
using FluentValidation;
using Gas.Domain.Entities;
using Gas.Domain.Entity.CompanyManagement;
using Gas.Model.CompanyManagement;
using Gas.Services.CompanyManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.UserFeatures.CommandHandler
{
    public record StaffLoginCommand(RequestStaffLoginEntity Request) : IRequest<Result<StaffEntity>>;

    internal class StaffLoginCommandHandler : IRequestHandler<StaffLoginCommand, Result<StaffEntity>>
    {
        private readonly IMapper _mapper;
        public StaffLoginCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<StaffEntity>> Handle(StaffLoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new StaffService().StaffLogin(request.Request);
                if (resp  != null )
                {
                    return await Result<StaffEntity>.SuccessAsync(resp);
                }
                else
                {
                    return await Result<StaffEntity>.FailureAsync("Invalid Username and password");
                }

            }
            catch (Exception e)
            {
                return await Result<StaffEntity>.FailureAsync(e.Message);
            }
        }

    }

}

using AutoMapper;
using FluentValidation;
using Gas.Domain.Entities;
using Gas.Model.CompanyManagement;
using Gas.Services.CompanyManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.UserFeatures.CommandHandler
{
    public record StaffChangePasswordOnLoginCommand(RequestStaffpassChangeModel Request) : IRequest<Result<QueryResEntity>>;

    internal class StaffChangePasswordOnLoginCommandHandler : IRequestHandler<StaffChangePasswordOnLoginCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public StaffChangePasswordOnLoginCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(StaffChangePasswordOnLoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new StaffService().StaffChangePasswordOnLogin(request.Request);
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

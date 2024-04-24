using AutoMapper;
using FluentValidation;
using Gas.Domain.Entities;
using Gas.Domain.Entity.CompanyManagement;
using Gas.Model.CompanyManagement;
using Gas.Services;
using Gas.Services.CompanyManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.AccountFeatures.CommandHandler
{
    public record StaffLoginTokenCommand(RequestStaffLoginEntity Request) : IRequest<Result<StaffTokenEntity>>;

    internal class StaffLoginTokenCommandHandler : IRequestHandler<StaffLoginTokenCommand, Result<StaffTokenEntity>>
    {
        public async Task<Result<StaffTokenEntity>> Handle(StaffLoginTokenCommand request, CancellationToken cancellationToken)
        {
            try
            {
                StaffTokenEntity respTokenEntity = new();

                var resp = new StaffService().StaffLogin(request.Request);
                GetStaffroleModel? rqModel = new()
                {
                    Staffid = resp.Staff_id
                };
                var resprole = new StaffroleService().GetStaffrole(rqModel);
                if (resp  != null )
                {
                    StaffLoginEntity staffLoginEntity = new ()
                    {
                        StaffDetails = resp,
                        StaffRole = (List<StaffRoleEntity>)resprole
                    };
                    respTokenEntity.Access_token =  Authentication.TokenAuthentication(staffLoginEntity);
                    respTokenEntity.Expires_in = (int)TimeSpan.FromHours(4).TotalSeconds;
                    respTokenEntity.Token_type = "Bearer";
                    respTokenEntity.Message = "Granted";

                    return await Result<StaffTokenEntity>.SuccessAsync(respTokenEntity);
                }
                else
                {
                    return await Result<StaffTokenEntity>.FailureAsync("Invalid Username and password");
                }

            }
            catch (Exception e)
            {
                return await Result<StaffTokenEntity>.FailureAsync(e.Message);
            }
        }

    }

}

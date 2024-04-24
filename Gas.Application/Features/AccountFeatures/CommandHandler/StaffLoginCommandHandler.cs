using Gas.Common;
using Gas.Domain.Entity.CompanyManagement;
using Gas.Model.CompanyManagement;
using Gas.Services;
using Gas.Services.CompanyManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.AccountFeatures.CommandHandler
{
    public record StaffLoginCommand(RequestStaffLoginEntity Request) : IRequest<Result<StaffLoginEntity>>;

    internal class StaffLoginCommandHandler : IRequestHandler<StaffLoginCommand, Result<StaffLoginEntity>>
    {
        public async Task<Result<StaffLoginEntity>> Handle(StaffLoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
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
                    if(resp.Super_dealer_id == null || resp.Super_dealer_id == 0)
                    {
                        return await Result<StaffLoginEntity>.FailureAsync($"User {resp.First_name} {resp.Middle_name} {resp.Last_name} does not belong to any Super Dealer Registered");
                    }
                    UserData.SuperDealerId = resp.Super_dealer_id;
                    staffLoginEntity.Token = Authentication.TokenAuthentication(staffLoginEntity);
                    return await Result<StaffLoginEntity>.SuccessAsync(staffLoginEntity);
                }
                else
                {
                    return await Result<StaffLoginEntity>.FailureAsync("Invalid Username and password");
                }

            }
            catch (Exception e)
            {
                return await Result<StaffLoginEntity>.FailureAsync(e.Message);
            }
        }

    }

}

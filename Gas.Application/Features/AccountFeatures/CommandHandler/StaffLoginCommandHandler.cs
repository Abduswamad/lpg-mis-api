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
    public record StaffLoginCommand(RequestStaffLoginEntity Request) : IRequest<Result<StaffLoginEntity>>;

    internal class StaffLoginCommandHandler : IRequestHandler<StaffLoginCommand, Result<StaffLoginEntity>>
    {
        private readonly IMapper _mapper;
        public StaffLoginCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
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
                    StaffLoginEntity staffLoginEntity = new StaffLoginEntity()
                    {
                        StaffDetails = resp,
                        StaffRole = (List<StaffRoleEntity>)resprole
                    };
                    staffLoginEntity.Token = new Authentication().Token_Authentication(staffLoginEntity);
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

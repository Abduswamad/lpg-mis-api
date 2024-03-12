
using FluentValidation;
using Gas.Model.CompanyManagement;

namespace Gas.Application.Features.RoleFeatures.Validator
{
    public class UpdateRoleValidator:AbstractValidator<UpdateRoleModel>
    {
        public UpdateRoleValidator()
        {

            RuleFor(x => x.Rolename).NotEmpty().WithMessage("Role Name cannot be null or empty");
        }

    }
}

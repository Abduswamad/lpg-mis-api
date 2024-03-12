using FluentValidation;
using Gas.Model.CompanyManagement;

namespace Gas.Application.Features.RoleFeatures.Validator
{
    public class AddRoleValidator:AbstractValidator<AddRoleModel>
    {
        public AddRoleValidator()
        {

            RuleFor(x => x.Rolename).NotEmpty().WithMessage("Role Name cannot be null or empty");
        }


    }
}

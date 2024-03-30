using FluentValidation;
using Gas.Model.CompanyManagement;
using Gas.Model.StoreManagement;

namespace Gas.Application.Features.AccountFeatures.Validator
{
    public class ChangePasswordOnLoginValidator : AbstractValidator<RequestStaffpassChangeOnLoginModel>
    {
        public ChangePasswordOnLoginValidator()
        {

            RuleFor(x => x.Staffusername).NotEmpty().WithMessage("Username cannot be null or empty");
            RuleFor(x => x.Staffpassword).NotEmpty().WithMessage("Staff Password cannot be null or empty")
               .Must(BeValidPassword).WithMessage("Staff Password must be at least 8 character with caps,small letter,number and special characters");
        }

        private bool BeValidPassword(string password)
        {
            return Helper.IsPasswordValid(password);
        }
    }
}

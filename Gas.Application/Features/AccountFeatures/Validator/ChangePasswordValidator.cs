
using FluentValidation;
using Gas.Model.CompanyManagement;

namespace Gas.Application.Features.AccountFeatures.Validator
{
    public class ChangePasswordValidator : AbstractValidator<RequestStaffpassChangeModel>
    {
        public ChangePasswordValidator()
        {

            RuleFor(x => x.Staffid).NotEmpty().WithMessage("Staff id cannot be null or empty")
                .Must(BeValidNumber).WithMessage("Staff id cannot be zero or less than zero");
            RuleFor(x => x.Staffpassword).NotEmpty().WithMessage("Staff Password cannot be null or empty")
               .Must(BeValidPassword).WithMessage("Staff Password must be at least 8 character with caps,small letter,number and special characters");
        }

        private bool BeValidNumber(int number)
        {

            return number > 0;
        }

        private bool BeValidPassword(string password)
        {
            return Helper.IsPasswordValid(password);
        }
    }
}

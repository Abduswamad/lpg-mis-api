using FluentValidation;
using Gas.Model.CompanyManagement;

namespace Gas.Application.Features.StaffFeatures.Validator
{
    public class AddStaffValidator:AbstractValidator<AddStaffModel>
    {
        public AddStaffValidator()
        {

            RuleFor(x => x.Staffusername).NotEmpty().WithMessage("Staff Name cannot be null or empty");
            RuleFor(x => x.Firstname).NotEmpty().WithMessage("Staff First Name cannot be null or empty");
            RuleFor(x => x.Lastname).NotEmpty().WithMessage("Staff Last Name cannot be null or empty");
            RuleFor(x => x.Phonenumber).NotEmpty()
               .Must(BeValidPhone).WithMessage("Staff PhoneNumber is not valid")
               .When(model => !string.IsNullOrEmpty(model.Phonenumber));
            RuleFor(x => x.Staffemail).NotEmpty()
               .Must(BeValidEmail).WithMessage("Staff Email is not valid")
               .When(model => !string.IsNullOrEmpty(model.Staffemail));
            RuleFor(x => x.Stafftype).NotEmpty().WithMessage("Staff Type cannot be null or empty")
                    .Must(BeValidNumber).WithMessage("Staff Type cannot be zero or less than zero");
            RuleFor(x => x.Staffgender).NotEmpty().WithMessage("Staff Gender cannot be null or empty")
                    .Must(BeValidNumber).WithMessage("Staff Gender cannot be zero or less than zero");
            RuleFor(x => x.Superdealer).NotEmpty().WithMessage("Super Delear cannot be null or empty")
                    .Must(BeValidNumber).WithMessage("Super Delear cannot be zero or less than zero");
        }

        private bool BeValidEmail(string email)
        {
           
            return Helper.IsEmailValid(email);
        }

        private bool BeValidPhone(string phone)
        {
            return Helper.IsPhoneNumberValid(phone);
        }

        private bool BeValidNumber(int? number)
        {

            return number > 0;
        }

    }
}

using FluentValidation;
using Gas.Model.CompanyManagement;

namespace Gas.Application.Features.AccessoryFeatures.Validator
{
    public class AddAccessoryValidator:AbstractValidator<AddAccessoryModel>
    {
        public AddAccessoryValidator()
        {

            RuleFor(x => x.Accessoryname).NotEmpty().WithMessage("Accessory Name cannot be null or empty");
            RuleFor(x => x.Accessorybrand).NotEmpty().WithMessage("Accessory Brand cannot be null or empty")
                   .Must(BeValidNumber).WithMessage("Accessory Brand cannot be zero or less than zero");
            RuleFor(x => x.Superdealer).NotEmpty().WithMessage("Super Delear cannot be null or empty")
                    .Must(BeValidNumber).WithMessage("Super Delear cannot be zero or less than zero");
        }

        private bool BeValidNumber(int? number)
        {
            return number > 0;
        }

    }
}

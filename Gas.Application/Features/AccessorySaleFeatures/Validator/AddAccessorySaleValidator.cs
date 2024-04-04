using FluentValidation;
using Gas.Model.SalesManagement;

namespace Gas.Application.Features.AccessorySaleFeatures.Validator
{
    public class AddAccessorySaleValidator:AbstractValidator<AddAccessorySaleModel>
    {
        public AddAccessorySaleValidator()
        {

            RuleFor(x => x.Accessoryid).NotEmpty().WithMessage("Accessory id cannot be null or empty")
                   .Must(BeValidNumber).WithMessage("Accessory id cannot be zero or less than zero");
            RuleFor(x => x.Salequantity).NotEmpty().WithMessage("Sale quantity cannot be null or empty")
                    .Must(BeValidNumber).WithMessage("Sale quantity cannot be zero or less than zero");
            RuleFor(x => x.Saleprice).NotEmpty().WithMessage("Selling Price cannot be null or empty")
                    .Must(BeValidFloat).WithMessage("Selling Price cannot be zero or less than zero");
            RuleFor(x => x.Saledate).NotNull().WithMessage("Sale date is required.");
        }

        private bool BeValidNumber(int? number)
        {
            return number > 0;
        }
        private bool BeValidFloat(double? number)
        {
            return number > 0;
        }

    }

}

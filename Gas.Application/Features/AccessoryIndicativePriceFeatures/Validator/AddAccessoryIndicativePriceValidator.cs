using FluentValidation;
using Gas.Model.SalesManagement;

namespace Gas.Application.Features.AccessoryIndicativePriceFeatures.Validator
{
    public class AddAccessoryIndicativePriceValidator:AbstractValidator<AddAccessoryIndicativePriceModel>
    {
        public AddAccessoryIndicativePriceValidator()
        {

            RuleFor(x => x.Accessoryid).NotEmpty().WithMessage("Accessory id cannot be null or empty")
                   .Must(BeValidNumber).WithMessage("Accessory id cannot be zero or less than zero");
            RuleFor(x => x.Buyingprice).NotEmpty().WithMessage("Buying Price cannot be null or empty")
                    .Must(BeValidFloat).WithMessage("Buying Price cannot be zero or less than zero");
            RuleFor(x => x.Sellingprice).NotEmpty().WithMessage("Selling Price cannot be null or empty")
                    .Must(BeValidFloat).WithMessage("Selling Price cannot be zero or less than zero");
        }

        private bool BeValidNumber(int? number)
        {
            return number > 0;
        }
        private bool BeValidFloat(float? number)
        {
            return number > 0;
        }

    }

}

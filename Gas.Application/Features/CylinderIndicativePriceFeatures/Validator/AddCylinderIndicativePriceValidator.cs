using FluentValidation;
using Gas.Model.SalesManagement;

namespace Gas.Application.Features.CylinderIndicativePriceFeatures.Validator
{
    public class AddCylinderIndicativePriceValidator:AbstractValidator<AddCylinderIndicativePriceModel>
    {
        public AddCylinderIndicativePriceValidator()
        {

            RuleFor(x => x.Cylinderid).NotEmpty().WithMessage("Cylinder id cannot be null or empty")
                   .Must(BeValidNumber).WithMessage("Cylinder id cannot be zero or less than zero");
            RuleFor(x => x.Cylindercategory).NotEmpty().WithMessage("Cylinder category cannot be null or empty")
                  .Must(BeValidNumber).WithMessage("Cylinder category cannot be zero or less than zero");
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

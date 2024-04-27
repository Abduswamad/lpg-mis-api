using FluentValidation;
using Gas.Model.SalesManagement;

namespace Gas.Application.Features.AccessorySaleFeatures.Validator
{
    public class AddAccessorySaleValidator:AbstractValidator<AddAccessorySaleModel>
    {
        public AddAccessorySaleValidator()
        {

            RuleFor(x => x.Superdealer).NotEmpty().WithMessage("Superdealer cannot be null or empty")
                    .Must(BeValidNumber).WithMessage("Superdealer cannot be zero or less than zero");
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

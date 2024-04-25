using FluentValidation;
using Gas.Model.SalesManagement;

namespace Gas.Application.Features.CylinderSaleFeatures.Validator
{
    public class AddCylinderSaleValidator:AbstractValidator<AddCylinderSaleModel>
    {
        public AddCylinderSaleValidator()
        {

            RuleFor(x => x.Saleprice).NotEmpty().WithMessage("Selling Price cannot be null or empty")
                    .Must(BeValidFloat).WithMessage("Selling Price cannot be zero or less than zero");
            RuleFor(x => x.Saledate).NotNull().WithMessage("Sale date is required.");
        }

        //private bool BeValidNumber(int? number)
        //{
        //    return number > 0;
        //}
        private bool BeValidFloat(double? number)
        {
            return number > 0;
        }

    }

}

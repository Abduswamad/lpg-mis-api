using FluentValidation;
using Gas.Model.SalesManagement;

namespace Gas.Application.Features.CylinderSaleFeatures.Validator
{

    public class CylinderSalesItemListModelValidator : AbstractValidator<AddCylinderSalesItemModel>
    {
        public CylinderSalesItemListModelValidator()
        {
            //RuleFor(x => x.CylinderSaleId).NotNull().WithMessage("Cylinder Sales ID is required.");
            RuleFor(x => x.CylinderCategory).NotNull().WithMessage("Cylinder Category ID is required.");
            RuleFor(x => x.CylinderId).NotNull().WithMessage("Cylinder Id is required.");
            RuleFor(x => x.SaleQuantity).NotNull().WithMessage("Cylinder Quantity is required.");
            RuleFor(x => x.Saleprice).NotNull().WithMessage("Cylinder Price is required.");
        }
    }

    public class AddCylinderSalesItemListModelValidator : AbstractValidator<AddCylinderSalesWithItemModel>
    {
        public AddCylinderSalesItemListModelValidator()
        {
            RuleFor(x => x.Superdealer).NotEmpty().WithMessage("Superdealer cannot be null or empty")
                    .Must(BeValidNumber).WithMessage("Superdealer cannot be zero or less than zero");
            RuleFor(x => x.Saleprice).NotEmpty().WithMessage("Selling Price cannot be null or empty")
                    .Must(BeValidFloat).WithMessage("Selling Price cannot be zero or less than zero");
            RuleFor(x => x.Saledate).NotNull().WithMessage("Sale date is required.");
            RuleForEach(x => x.CylinderSalesItem).SetValidator(new CylinderSalesItemListModelValidator()!);
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

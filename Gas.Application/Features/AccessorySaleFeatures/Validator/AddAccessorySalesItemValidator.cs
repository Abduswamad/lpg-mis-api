using FluentValidation;
using Gas.Model.SalesManagement;
using Gas.Model.StoreManagement;

namespace Gas.Application.Features.AccessorySaleFeatures.Validator
{

    public class AccessorySalesItemListModelValidator : AbstractValidator<AddAccessorySaleItemModel>
    {
        public AccessorySalesItemListModelValidator()
        {
            //RuleFor(x => x.Accessorysaleid).NotNull().WithMessage("Accessory Sales ID is required.");
            RuleFor(x => x.AccessoryId).NotNull().WithMessage("Accessory Id is required.");
            RuleFor(x => x.SaleQuantity).NotNull().WithMessage("Accessory Quantity is required.");
            RuleFor(x => x.Saleprice).NotNull().WithMessage("Accessory Price is required.");
        }
    }

    public class AddAccessorySalesItemListModelValidator : AbstractValidator<AddAccessorySaleWithItemModel>
    {
        public AddAccessorySalesItemListModelValidator()
        {
            RuleFor(x => x.Superdealer).NotEmpty().WithMessage("Superdealer cannot be null or empty")
                    .Must(BeValidNumber).WithMessage("Superdealer cannot be zero or less than zero");
            RuleFor(x => x.Saleprice).NotEmpty().WithMessage("Selling Price cannot be null or empty")
                    .Must(BeValidFloat).WithMessage("Selling Price cannot be zero or less than zero");
            RuleFor(x => x.Saledate).NotNull().WithMessage("Sale date is required.");
            RuleForEach(x => x.AccessorySalesItem).SetValidator(new AccessorySalesItemListModelValidator()!);
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

using FluentValidation;
using Gas.Model.SalesManagement;

namespace Gas.Application.Features.CylinderSaleFeatures.Validator
{
    public class DeleteCylinderSalesItemValidator : AbstractValidator<DeleteCylinderSalesItemModel>
    {
        public DeleteCylinderSalesItemValidator()
        {
            RuleFor(x => x.CylinderSaleid).NotEmpty().WithMessage("Cylinder Sale id cannot be null or empty")
                   .Must(BeValidNumber).WithMessage("Cylinder Sale id cannot be zero or less than zero");
            RuleFor(x => x.CylinderSaleItemid).NotEmpty().WithMessage("Cylinder Sales Item id cannot be null or empty")
                   .Must(BeValidNumber).WithMessage("Cylinder Sales Item id cannot be zero or less than zero");
        }

        private bool BeValidNumber(int? number)
        {
            return number > 0;
        }

    }

}

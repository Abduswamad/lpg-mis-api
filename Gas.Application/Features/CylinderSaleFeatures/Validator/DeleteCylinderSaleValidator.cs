using FluentValidation;
using Gas.Model.SalesManagement;

namespace Gas.Application.Features.CylinderSaleFeatures.Validator
{
    public class DeleteCylinderSaleValidator : AbstractValidator<DeleteCylinderSaleModel>
    {
        public DeleteCylinderSaleValidator()
        {
            RuleFor(x => x.CylinderSaleid).NotEmpty().WithMessage("Cylinder Sale id cannot be null or empty")
                   .Must(BeValidNumber).WithMessage("Cylinder Sale id cannot be zero or less than zero");
        }

        private bool BeValidNumber(int? number)
        {
            return number > 0;
        }

    }

}

using FluentValidation;
using Gas.Model.SalesManagement;

namespace Gas.Application.Features.AccessorySaleFeatures.Validator
{
    public class DeleteAccessorySaleValidator : AbstractValidator<DeleteAccessorySaleModel>
    {
        public DeleteAccessorySaleValidator()
        {
            RuleFor(x => x.AccessorySaleid).NotEmpty().WithMessage("Accessory Sale id cannot be null or empty")
                   .Must(BeValidNumber).WithMessage("Accessory Sale id cannot be zero or less than zero");
        }

        private bool BeValidNumber(int? number)
        {
            return number > 0;
        }

    }

}

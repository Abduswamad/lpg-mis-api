
using FluentValidation;
using Gas.Model.PublicManagement;

namespace Gas.Application.Features.AccessorybrandFeatures.Validator
{
    public class UpdateAccessorybrandValidator:AbstractValidator<UpdateAccessorybrandModel>
    {
        public UpdateAccessorybrandValidator()
        {

            RuleFor(x => x.Accessorybrandname).NotEmpty().WithMessage("Accessorybrand Name cannot be null or empty");
        }

    }
}

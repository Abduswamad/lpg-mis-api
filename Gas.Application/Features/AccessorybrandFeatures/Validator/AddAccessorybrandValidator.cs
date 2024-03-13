using FluentValidation;
using Gas.Model.PublicManagement;

namespace Gas.Application.Features.AccessorybrandFeatures.Validator
{
    public class AddAccessorybrandValidator:AbstractValidator<AddAccessorybrandModel>
    {
        public AddAccessorybrandValidator()
        {

            RuleFor(x => x.Accessorybrandname).NotEmpty().WithMessage("Accessorybrand Name cannot be null or empty");
        }


    }
}

using FluentValidation;
using Gas.Model.PublicManagement;

namespace Gas.Application.Features.SuperdealerFeatures.Validator
{
    public class AddSuperdealerValidator:AbstractValidator<AddSuperdealerModel>
    {
        public AddSuperdealerValidator()
        {

            RuleFor(x => x.Superdealername).NotEmpty().WithMessage("Superdealer Name cannot be null or empty");
        }


    }
}

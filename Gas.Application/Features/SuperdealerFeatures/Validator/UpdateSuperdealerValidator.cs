

using FluentValidation;
using Gas.Model.PublicManagement;

namespace Gas.Application.Features.SuperdealerFeatures.Validator
{
    public class UpdateSuperdealerValidator:AbstractValidator<UpdateSuperdealerModel>
    {
        public UpdateSuperdealerValidator()
        {

            RuleFor(x => x.Superdealername).NotEmpty().WithMessage("Superdealer Name cannot be null or empty");
        }

    }
}

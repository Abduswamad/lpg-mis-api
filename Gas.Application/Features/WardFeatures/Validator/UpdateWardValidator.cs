
using FluentValidation;
using Gas.Model.PublicManagement;

namespace Gas.Application.Features.WardFeatures.Validator
{
    public class UpdateWardValidator:AbstractValidator<UpdateWardModel>
    {
        public UpdateWardValidator()
        {

            RuleFor(x => x.Wardname).NotEmpty().WithMessage("Ward Name cannot be null or empty");
        }

    }
}

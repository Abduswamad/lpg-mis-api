using FluentValidation;
using Gas.Model.PublicManagement;

namespace Gas.Application.Features.WardFeatures.Validator
{
    public class AddWardValidator:AbstractValidator<AddWardModel>
    {
        public AddWardValidator()
        {

            RuleFor(x => x.Wardname).NotEmpty().WithMessage("Ward Name cannot be null or empty");
        }


    }
}

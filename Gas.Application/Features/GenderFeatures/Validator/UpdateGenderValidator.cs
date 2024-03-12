
using FluentValidation;
using Gas.Model.PublicManagement;

namespace Gas.Application.Features.GenderFeatures.Validator
{
    public class UpdateGenderValidator:AbstractValidator<UpdateGenderModel>
    {
        public UpdateGenderValidator()
        {

            RuleFor(x => x.Gendername).NotEmpty().WithMessage("Gender Name cannot be null or empty");
        }

    }
}

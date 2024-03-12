
using FluentValidation;
using Gas.Model.PublicManagement;

namespace Gas.Application.Features.CylindercategoryFeatures.Validator
{
    public class UpdateCylindercategoryValidator:AbstractValidator<UpdateCylindercategoryModel>
    {
        public UpdateCylindercategoryValidator()
        {

            RuleFor(x => x.Cylindercategoryname).NotEmpty().WithMessage("Cylindercategory Name cannot be null or empty");
        }

    }
}

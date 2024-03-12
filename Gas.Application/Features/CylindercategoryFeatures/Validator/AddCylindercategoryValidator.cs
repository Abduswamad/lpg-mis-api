using FluentValidation;
using Gas.Model.PublicManagement;

namespace Gas.Application.Features.CylindercategoryFeatures.Validator
{
    public class AddCylindercategoryValidator:AbstractValidator<AddCylindercategoryModel>
    {
        public AddCylindercategoryValidator()
        {

            RuleFor(x => x.Cylindercategoryname).NotEmpty().WithMessage("Cylindercategory Name cannot be null or empty");
        }


    }
}

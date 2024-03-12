using FluentValidation;
using Gas.Model.PublicManagement;

namespace Gas.Application.Features.CylindercompanyFeatures.Validator
{
    public class AddCylindercompanyValidator:AbstractValidator<AddCylindercompanyModel>
    {
        public AddCylindercompanyValidator()
        {

            RuleFor(x => x.Cylindercompanyname).NotEmpty().WithMessage("Cylindercompany Name cannot be null or empty");
        }


    }
}

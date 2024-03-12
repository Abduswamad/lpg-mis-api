
using FluentValidation;
using Gas.Model.PublicManagement;

namespace Gas.Application.Features.CylindercompanyFeatures.Validator
{
    public class UpdateCylindercompanyValidator:AbstractValidator<UpdateCylindercompanyModel>
    {
        public UpdateCylindercompanyValidator()
        {

            RuleFor(x => x.Cylindercompanyname).NotEmpty().WithMessage("Cylindercompany Name cannot be null or empty");
        }

    }
}


using FluentValidation;
using Gas.Model.CompanyManagement;

namespace Gas.Application.Features.CylinderFeatures.Validator
{
    public class UpdateCylinderValidator:AbstractValidator<UpdateCylinderModel>
    {
        public UpdateCylinderValidator()
        {

            RuleFor(x => x.Cylindername).NotEmpty().WithMessage("Cylinder Name cannot be null or empty");
            RuleFor(x => x.Cylindercategory).NotEmpty().WithMessage("Cylinder Category cannot be null or empty")
                    .Must(BeValidNumber).WithMessage("Cylinder Category cannot be zero or less than zero");
            RuleFor(x => x.Cylindercompany).NotEmpty().WithMessage("Cylinder Company cannot be null or empty")
                   .Must(BeValidNumber).WithMessage("Cylinder Company cannot be zero or less than zero");
            RuleFor(x => x.Superdealer).NotEmpty().WithMessage("Super Delear cannot be null or empty")
                    .Must(BeValidNumber).WithMessage("Super Delear cannot be zero or less than zero");
        }

        private bool BeValidNumber(int? number)
        {
            return number > 0;
        }


    }
}

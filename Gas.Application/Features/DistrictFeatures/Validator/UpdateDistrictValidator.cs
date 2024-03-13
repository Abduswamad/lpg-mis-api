
using FluentValidation;
using Gas.Model.PublicManagement;

namespace Gas.Application.Features.DistrictFeatures.Validator
{
    public class UpdateDistrictValidator:AbstractValidator<UpdateDistrictModel>
    {
        public UpdateDistrictValidator()
        {

            RuleFor(x => x.Districtname).NotEmpty().WithMessage("District Name cannot be null or empty");
        }

    }
}

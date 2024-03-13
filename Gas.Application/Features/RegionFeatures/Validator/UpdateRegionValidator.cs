
using FluentValidation;
using Gas.Model.PublicManagement;

namespace Gas.Application.Features.RegionFeatures.Validator
{
    public class UpdateRegionValidator:AbstractValidator<UpdateRegionModel>
    {
        public UpdateRegionValidator()
        {

            RuleFor(x => x.Regionname).NotEmpty().WithMessage("Region Name cannot be null or empty");
        }

    }
}

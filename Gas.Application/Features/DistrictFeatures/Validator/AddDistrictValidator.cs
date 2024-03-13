using FluentValidation;
using Gas.Model.PublicManagement;

namespace Gas.Application.Features.DistrictFeatures.Validator
{
    public class AddDistrictValidator:AbstractValidator<AddDistrictModel>
    {
        public AddDistrictValidator()
        {

            RuleFor(x => x.Districtname).NotEmpty().WithMessage("District Name cannot be null or empty");
        }


    }
}


using FluentValidation;
using Gas.Model.PublicManagement;

namespace Gas.Application.Features.CountryFeatures.Validator
{
    public class UpdateCountryValidator:AbstractValidator<UpdateCountryModel>
    {
        public UpdateCountryValidator()
        {

            RuleFor(x => x.Countryname).NotEmpty().WithMessage("Country Name cannot be null or empty");
        }

    }
}

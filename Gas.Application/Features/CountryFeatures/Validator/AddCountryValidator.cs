using FluentValidation;
using Gas.Model.PublicManagement;

namespace Gas.Application.Features.CountryFeatures.Validator
{
    public class AddCountryValidator:AbstractValidator<AddCountryModel>
    {
        public AddCountryValidator()
        {

            RuleFor(x => x.Countryname).NotEmpty().WithMessage("Country Name cannot be null or empty");
        }


    }
}

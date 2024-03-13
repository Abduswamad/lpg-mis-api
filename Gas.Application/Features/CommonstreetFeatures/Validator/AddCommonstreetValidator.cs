using FluentValidation;
using Gas.Model.PublicManagement;

namespace Gas.Application.Features.CommonstreetFeatures.Validator
{
    public class AddCommonstreetValidator:AbstractValidator<AddCommonstreetModel>
    {
        public AddCommonstreetValidator()
        {

            RuleFor(x => x.Commonstreetname).NotEmpty().WithMessage("Commonstreet Name cannot be null or empty");
        }


    }
}

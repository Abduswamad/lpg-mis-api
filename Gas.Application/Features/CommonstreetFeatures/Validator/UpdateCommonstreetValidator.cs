
using FluentValidation;
using Gas.Model.PublicManagement;

namespace Gas.Application.Features.CommonstreetFeatures.Validator
{
    public class UpdateCommonstreetValidator:AbstractValidator<UpdateCommonstreetModel>
    {
        public UpdateCommonstreetValidator()
        {

            RuleFor(x => x.Commonstreetname).NotEmpty().WithMessage("Commonstreet Name cannot be null or empty");
        }

    }
}

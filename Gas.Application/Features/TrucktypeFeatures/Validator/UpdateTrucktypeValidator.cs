
using FluentValidation;
using Gas.Model.PublicManagement;

namespace Gas.Application.Features.TrucktypeFeatures.Validator
{
    public class UpdateTrucktypeValidator:AbstractValidator<UpdateTrucktypeModel>
    {
        public UpdateTrucktypeValidator()
        {

            RuleFor(x => x.Trucktypename).NotEmpty().WithMessage("Trucktype Name cannot be null or empty");
        }

    }
}

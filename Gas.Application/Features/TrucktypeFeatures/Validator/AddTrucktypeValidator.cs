using FluentValidation;
using Gas.Model.PublicManagement;

namespace Gas.Application.Features.TrucktypeFeatures.Validator
{
    public class AddTrucktypeValidator:AbstractValidator<AddTrucktypeModel>
    {
        public AddTrucktypeValidator()
        {

            RuleFor(x => x.Trucktypename).NotEmpty().WithMessage("Trucktype Name cannot be null or empty");
        }


    }
}

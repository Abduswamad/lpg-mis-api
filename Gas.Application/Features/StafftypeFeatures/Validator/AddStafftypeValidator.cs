using FluentValidation;
using Gas.Model.CompanyManagement;

namespace Gas.Application.Features.StafftypeFeatures.Validator
{
    public class AddStafftypeValidator:AbstractValidator<AddStafftypeModel>
    {
        public AddStafftypeValidator()
        {

            RuleFor(x => x.Stafftypename).NotEmpty().WithMessage("Stafftype Name cannot be null or empty");
        }


    }
}

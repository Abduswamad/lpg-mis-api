using FluentValidation;
using Gas.Model.CompanyManagement;

namespace Gas.Application.Features.StaffroleFeatures.Validator
{
    public class AddStaffroleValidator:AbstractValidator<AddStaffroleModel>
    {
        public AddStaffroleValidator()
        {

            RuleFor(x => x.Staffid).NotEmpty().WithMessage("Staff ID cannot be null or empty");
        }


    }
}

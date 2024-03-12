
using FluentValidation;
using Gas.Model.CompanyManagement;

namespace Gas.Application.Features.DepoFeatures.Validator
{
    public class UpdateDepoValidator:AbstractValidator<UpdateDepoModel>
    {
        public UpdateDepoValidator()
        {

            RuleFor(x => x.Deponame).NotEmpty().WithMessage("Depo Name cannot be null or empty");
            RuleFor(x => x.Commonstreet).NotEmpty().WithMessage("Depo Street cannot be null or empty")
                    .Must(BeValidNumber).WithMessage("Depo Street cannot be zero or less than zero");
            RuleFor(x => x.Superdealer).NotEmpty().WithMessage("Super Delear cannot be null or empty")
                    .Must(BeValidNumber).WithMessage("Super Delear cannot be zero or less than zero");
        }

        private bool BeValidNumber(int? number)
        {
            return number > 0;
        }


    }
}

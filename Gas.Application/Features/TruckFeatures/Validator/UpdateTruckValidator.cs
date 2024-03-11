
using FluentValidation;
using Gas.Model.CompanyManagement;

namespace Gas.Application.Features.TruckFeatures.Validator
{
    public class UpdateTruckValidator:AbstractValidator<UpdateTruckModel>
    {
        public UpdateTruckValidator()
        {

            RuleFor(x => x.Platenumber).NotEmpty().WithMessage("Truck Name cannot be null or empty");
            RuleFor(x => x.Trucktype).NotEmpty().WithMessage("Truck Type cannot be null or empty")
                    .Must(BeValidNumber).WithMessage("Truck Type cannot be zero or less than zero");
            RuleFor(x => x.Truckdriver).NotEmpty().WithMessage("Truck Driver cannot be null or empty")
                    .Must(BeValidNumber).WithMessage("Truck Driver cannot be zero or less than zero");
            RuleFor(x => x.Superdealer).NotEmpty().WithMessage("Super Delear cannot be null or empty")
                    .Must(BeValidNumber).WithMessage("Super Delear cannot be zero or less than zero");
            RuleFor(x => x.Truckid).NotEmpty().WithMessage("Truck Id cannot be null or empty")
                    .Must(BeValidNumber).WithMessage("Truck Id cannot be zero or less than zero");
            RuleFor(x => x.Weigthintones).NotEmpty().WithMessage("Truck Weigth cannot be null or empty")
                    .Must(BeValidFloat).WithMessage("Truck Weigth cannot be zero or less than zero");
        }

        private bool BeValidNumber(int? number)
        {
            return number > 0;
        }

        private bool BeValidFloat(float? number)
        {
            return number > 0;
        }

    }
}

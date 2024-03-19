using FluentValidation;
using Gas.Model.StoreManagement;

namespace Gas.Application.Features.BatchFeatures.Validator
{
    public class GetCylinderStoreValidator:AbstractValidator<CylinderstockModel>
    {
        public GetCylinderStoreValidator()
        {

            RuleFor(x => x.Store).NotEmpty().WithMessage("Store cannot be null or empty")
                    .Must(BeValidNumber).WithMessage("Store cannot be zero or less than zero");
            RuleFor(x => x.Stockdate).NotEmpty().WithMessage("Stock Date cannot be null or empty")
                  .Must(BeValidDate).WithMessage("Stock Date is not Valid");
        }

        private bool BeValidNumber(int? number)
        {

            return number > 0;
        }

        private bool BeValidDate(DateTime? date)
        {
            // Get today's date
            DateTime today = DateTime.Today;

            DateTime enteredDate;

            // Keep prompting the user until a valid date is entered
            while (!DateTime.TryParse(date?.ToLongDateString(), out enteredDate) || enteredDate > today)
            {
                return false;
            }

            return true;
        }

    }
}

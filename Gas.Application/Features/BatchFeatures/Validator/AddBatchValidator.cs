using FluentValidation;
using Gas.Model.StoreManagement;

namespace Gas.Application.Features.BatchFeatures.Validator
{
    public class AddBatchValidator:AbstractValidator<AddBatchModel>
    {
        public AddBatchValidator()
        {

            RuleFor(x => x.Batchtype).NotEmpty().WithMessage("Batch Type cannot be null or empty")
                    .Must(BeValidNumber).WithMessage("Batch Type cannot be zero or less than zero");
            RuleFor(x => x.Batchdepo).NotEmpty().WithMessage("Batch Depo cannot be null or empty")
                    .Must(BeValidNumber).WithMessage("Batch Depo cannot be zero or less than zero");
            RuleFor(x => x.Batchtruck).NotEmpty().WithMessage("Batch Truck cannot be null or empty")
                    .Must(BeValidNumber).WithMessage("Batch Truck cannot be zero or less than zero");
            RuleFor(x => x.Batchdriver).NotEmpty().WithMessage("Batch Drive cannot be null or empty")
                   .Must(BeValidNumber).WithMessage("Batch Drive cannot be zero or less than zero");
            RuleFor(x => x.Batchdriver).NotEmpty().WithMessage("Batch Drive cannot be null or empty")
                   .Must(BeValidNumber).WithMessage("Batch Drive cannot be zero or less than zero");
            RuleFor(x => x.Batchdate).NotEmpty().WithMessage("Batch Date cannot be null or empty")
                  .Must(BeValidDate).WithMessage("Batch Date is not Valid");
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

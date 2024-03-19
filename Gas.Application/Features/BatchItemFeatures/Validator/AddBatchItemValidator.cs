using FluentValidation;
using Gas.Model.StoreManagement;

namespace Gas.Application.Features.BatchItemFeatures.Validator
{
    public class AddBatchItemValidator:AbstractValidator<AddBatchItemModel>
    {
        public AddBatchItemValidator()
        {

            RuleFor(x => x.Batchid).NotEmpty().WithMessage("Batch Id cannot be null or empty")
                    .Must(BeValidNumber).WithMessage("Batch Id cannot be zero or less than zero");
            RuleFor(x => x.Cylinderid).NotEmpty().WithMessage("Cylinder Id cannot be null or empty")
                    .Must(BeValidNumber).WithMessage("Cylinder Id cannot be zero or less than zero");
            RuleFor(x => x.Cylinderstatus).NotEmpty().WithMessage("Cylinder Status cannot be null or empty")
                    .Must(BeValidNumber).WithMessage("Cylinder Status cannot be zero or less than zero");
            RuleFor(x => x.Cylinderquantity).NotEmpty().WithMessage("Cylinder Quantity cannot be null or empty")
                   .Must(BeValidNumber).WithMessage("Cylinder Quantity  cannot be zero or less than zero");
        }

        private bool BeValidNumber(int? number)
        {
            return number > 0;
        }


    }
}

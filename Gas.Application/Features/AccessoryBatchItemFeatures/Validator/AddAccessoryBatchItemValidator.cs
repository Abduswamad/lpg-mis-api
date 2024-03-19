using FluentValidation;
using Gas.Model.StoreManagement;

namespace Gas.Application.Features.AccessoryBatchItemFeatures.Validator
{
    public class AddAccessoryBatchItemValidator:AbstractValidator<AddAccessoryBatchItemModel>
    {
        public AddAccessoryBatchItemValidator()
        {

            RuleFor(x => x.Batchid).NotEmpty().WithMessage("Batch Id cannot be null or empty")
                    .Must(BeValidNumber).WithMessage("Batch Id cannot be zero or less than zero");
            RuleFor(x => x.Accessoryid).NotEmpty().WithMessage("Accessory Id cannot be null or empty")
                    .Must(BeValidNumber).WithMessage("Accessory Id cannot be zero or less than zero");
            RuleFor(x => x.Accessoryquantity).NotEmpty().WithMessage("Accessory Quantity cannot be null or empty")
                   .Must(BeValidNumber).WithMessage("Accessory Quantity  cannot be zero or less than zero");
        }

        private bool BeValidNumber(int? number)
        {
            return number > 0;
        }


    }
}

using FluentValidation;
using Gas.Model.StoreManagement;

namespace Gas.Application.Features.AccessoryBatchItemFeatures.Validator
{
    public class DeleteAccessoryBatchItemValidator:AbstractValidator<DelAccessoryBatchItemModel>
    {
        public DeleteAccessoryBatchItemValidator()
        {

            RuleFor(x => x.Batchid).NotEmpty().WithMessage("Batch Id cannot be null or empty")
                    .Must(BeValidNumber).WithMessage("Batch Id cannot be zero or less than zero");
        }

        private bool BeValidNumber(int? number)
        {
            return number > 0;
        }


    }
}

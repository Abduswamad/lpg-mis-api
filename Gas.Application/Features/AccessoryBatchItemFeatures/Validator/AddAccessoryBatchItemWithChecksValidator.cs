using FluentValidation;
using Gas.Model.StoreManagement;

namespace Gas.Application.Features.AccessoryBatchItemFeatures.Validator
{
    public class AccessoryBatchItemListModelValidator : AbstractValidator<AccessoryBatchItemListModel>
    {
        public AccessoryBatchItemListModelValidator()
        {
            RuleFor(x => x.Accessoryid).NotNull().WithMessage("Accessory ID is required.");
            RuleFor(x => x.Accessoryquantity).NotNull().WithMessage("Accessory quantity is required.");
        }
    }

    public class AddAccessoryBatchItemWithChecksModelValidator : AbstractValidator<AddAccessoryBatchItemWithChecksModel>
    {
        public AddAccessoryBatchItemWithChecksModelValidator()
        {
            RuleFor(x => x.Batchtype).NotNull().WithMessage("Batch type is required.");
            RuleFor(x => x.Batchtruck).NotNull().WithMessage("Batch truck is required.");
            RuleFor(x => x.Batchdriver).NotNull().WithMessage("Batch driver is required.");
            RuleFor(x => x.Batchdepo).NotNull().WithMessage("Batch depot is required.");
            RuleFor(x => x.Batchdate).NotNull().WithMessage("Batch date is required.");
            RuleFor(x => x.Store).NotNull().WithMessage("Store is required.");
            RuleFor(x => x.Stockdate).NotNull().WithMessage("Stock date is required.");
            RuleForEach(x => x.Accessors).SetValidator(new AccessoryBatchItemListModelValidator());
        }
    }
}

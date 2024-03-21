using FluentValidation;
using Gas.Model.StoreManagement;

namespace Gas.Application.Features.BatchItemFeatures.Validator
{
    public class CylinderBatchItemListModelValidator : AbstractValidator<CylinderBatchItemListModel>
    {
        public CylinderBatchItemListModelValidator()
        {
            RuleFor(x => x.Cylinderid).NotNull().WithMessage("Cylinder ID is required.");
            RuleFor(x => x.Cylinderstatus).NotNull().WithMessage("Cylinder status is required.");
            RuleFor(x => x.Cylinderquantity).NotNull().WithMessage("Cylinder quantity is required.");
        }
    }

    public class AddCylinderBatchItemWithChecksModelValidator : AbstractValidator<AddCylinderBatchItemWithChecksModel>
    {
        public AddCylinderBatchItemWithChecksModelValidator()
        {
            RuleFor(x => x.Batchtype).NotNull().WithMessage("Batch type is required.");
            RuleFor(x => x.Batchtruck).NotNull().WithMessage("Batch truck is required.");
            RuleFor(x => x.Batchdriver).NotNull().WithMessage("Batch driver is required.");
            RuleFor(x => x.Batchdepo).NotNull().WithMessage("Batch depot is required.");
            RuleFor(x => x.Batchdate).NotNull().WithMessage("Batch date is required.");
            RuleFor(x => x.Store).NotNull().WithMessage("Store is required.");
            RuleFor(x => x.Stockdate).NotNull().WithMessage("Stock date is required.");
            RuleForEach(x => x.Cylinders).SetValidator(new CylinderBatchItemListModelValidator());
        }
    }
}

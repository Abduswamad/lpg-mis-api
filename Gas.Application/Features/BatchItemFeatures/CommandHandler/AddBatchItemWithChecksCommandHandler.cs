using AutoMapper;
using Gas.Domain.Entities;
using Gas.Model.StoreManagement;
using Gas.Services.StoreManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.BatchItemFeatures.CommandHandler
{
    public record AddBatchItemWithChecksCommand(AddCylinderBatchItemWithChecksModel Request) : IRequest<Result<QueryResEntity>>;

    internal class AddBatchItemWithChecksCommandHandler : IRequestHandler<AddBatchItemWithChecksCommand, Result<QueryResEntity>>
    {
        public async Task<Result<QueryResEntity>> Handle(AddBatchItemWithChecksCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new BatchItemService().AddCylinderBatchItemWithChecks(request.Request);
                if (resp.Code == 200)
                {                    
                    return await Result<QueryResEntity>.SuccessAsync(resp, resp.Msg);
                }
                else
                {
                    return await Result<QueryResEntity>.FailureAsync(resp.Msg);
                }

            }
            catch (Exception e)
            {
                return await Result<QueryResEntity>.FailureAsync(e.Message);
            }
        }

    }

}

using AutoMapper;
using Gas.Domain.Entities;
using Gas.Model.StoreManagement;
using Gas.Services.StoreManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.BatchItemFeatures.CommandHandler
{
    public record AddFullBatchItemWithChecksCommand(AddBatchItemWithChecksModel Request) : IRequest<Result<QueryResEntity>>;

    internal class AddFullBatchItemWithChecksCommandHandler : IRequestHandler<AddFullBatchItemWithChecksCommand, Result<QueryResEntity>>
    {
        public async Task<Result<QueryResEntity>> Handle(AddFullBatchItemWithChecksCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new BatchItemService().AddBatchItemWithChecks(request.Request);
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

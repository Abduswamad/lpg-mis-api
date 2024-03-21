using AutoMapper;
using Gas.Domain.Entities;
using Gas.Model.StoreManagement;
using Gas.Services.StoreManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.AccessoryBatchItemFeatures.CommandHandler
{
    public record AddAccessoryBatchItemWithChecksCommand(AddAccessoryBatchItemWithChecksModel Request) : IRequest<Result<QueryResEntity>>;

    internal class AddAccessoryBatchItemWithChecksCommandHandler : IRequestHandler<AddAccessoryBatchItemWithChecksCommand, Result<QueryResEntity>>
    {
        
        public async Task<Result<QueryResEntity>> Handle(AddAccessoryBatchItemWithChecksCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new AccessoryBatchItemService().AddAccessoryBatchItemWithChecks(request.Request);
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

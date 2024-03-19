using AutoMapper;
using Gas.Domain.Entities;
using Gas.Model.StoreManagement;
using Gas.Services.StoreManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.BatchItemFeatures.CommandHandler
{
    public record DeleteBatchItemCommand(DelBatchItemModel Request) : IRequest<Result<QueryResEntity>>;

    internal class DeleteBatchItemCommandHandler : IRequestHandler<DeleteBatchItemCommand, Result<QueryResEntity>>
    {
        public async Task<Result<QueryResEntity>> Handle(DeleteBatchItemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new BatchItemService().DeleteBatchItem(request.Request);
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

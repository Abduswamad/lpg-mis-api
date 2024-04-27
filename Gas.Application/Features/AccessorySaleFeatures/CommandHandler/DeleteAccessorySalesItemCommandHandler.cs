using Gas.Domain.Entities;
using Gas.Model.SalesManagement;
using Gas.Services.SalesManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.AccessorySaleFeatures.CommandHandler
{
    public record DeleteAccessorySalesItemCommand(DeleteAccessorySalesItemModel Request) : IRequest<Result<QueryResEntity>>;

    internal class DeleteAccessorySalesItemCommandHandler : IRequestHandler<DeleteAccessorySalesItemCommand, Result<QueryResEntity>>
    {
        public async Task<Result<QueryResEntity>> Handle(DeleteAccessorySalesItemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new AccessorySaleService().DeleteAccessorySalesItem(request.Request);
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

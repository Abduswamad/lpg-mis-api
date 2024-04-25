using Gas.Domain.Entities;
using Gas.Model.SalesManagement;
using Gas.Services.SalesManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.CylinderSaleFeatures.CommandHandler
{
    public record DeleteCylinderSalesItemCommand(DeleteCylinderSalesItemModel Request) : IRequest<Result<QueryResEntity>>;

    internal class DeleteCylinderSalesItemCommandHandler : IRequestHandler<DeleteCylinderSalesItemCommand, Result<QueryResEntity>>
    {
        public async Task<Result<QueryResEntity>> Handle(DeleteCylinderSalesItemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new CylinderSaleService().DeleteCylinderSalesItem(request.Request);
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

using Gas.Domain.Entities;
using Gas.Model.SalesManagement;
using Gas.Services.SalesManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.CylinderSaleFeatures.CommandHandler
{
    public record DeleteCylinderSaleCommand(DeleteCylinderSaleModel Request) : IRequest<Result<QueryResEntity>>;

    internal class DeleteCylinderSaleCommandHandler : IRequestHandler<DeleteCylinderSaleCommand, Result<QueryResEntity>>
    {
        public async Task<Result<QueryResEntity>> Handle(DeleteCylinderSaleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new CylinderSaleService().DeleteCylinderSale(request.Request);
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

using Gas.Domain.Entities;
using Gas.Model.SalesManagement;
using Gas.Services.SalesManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.CylinderIndicativePriceFeatures.CommandHandler
{
    public record UpdateCylinderIndicativePriceCommand(UpdateCylinderIndicativePriceModel Request) : IRequest<Result<QueryResEntity>>;

    internal class UpdateCylinderIndicativePriceCommandHandler : IRequestHandler<UpdateCylinderIndicativePriceCommand, Result<QueryResEntity>>
    {
        public async Task<Result<QueryResEntity>> Handle(UpdateCylinderIndicativePriceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new CylinderIndicativePriceService().UpdateCylinderIndicativePrice(request.Request);
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

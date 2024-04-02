using Gas.Domain.Entities;
using Gas.Model.SalesManagement;
using Gas.Services.SalesManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.CylinderIndicativePriceFeatures.CommandHandler
{
    public record UpdateCylinderIndicativePriceStatusCommand(UpdateCylinderIndicativePriceStatusModel Request) : IRequest<Result<QueryResEntity>>;

    internal class UpdateCylinderIndicativePriceStatusCommandHandler : IRequestHandler<UpdateCylinderIndicativePriceStatusCommand, Result<QueryResEntity>>
    {
        public async Task<Result<QueryResEntity>> Handle(UpdateCylinderIndicativePriceStatusCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new CylinderIndicativePriceService().UpdateCylinderIndicativePriceStatus(request.Request);
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

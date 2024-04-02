using Gas.Domain.Entities;
using Gas.Model.SalesManagement;
using Gas.Services.SalesManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.AccessoryIndicativePriceFeatures.CommandHandler
{
    public record UpdateAccessoryIndicativePriceStatusCommand(UpdateAccessoryIndicativePriceStatusModel Request) : IRequest<Result<QueryResEntity>>;

    internal class UpdateAccessoryIndicativePriceStatusCommandHandler : IRequestHandler<UpdateAccessoryIndicativePriceStatusCommand, Result<QueryResEntity>>
    {
        public async Task<Result<QueryResEntity>> Handle(UpdateAccessoryIndicativePriceStatusCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new AccessoryIndicativePriceService().UpdateAccessoryIndicativePriceStatus(request.Request);
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

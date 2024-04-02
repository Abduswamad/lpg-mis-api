using AutoMapper;
using Gas.Domain.Entities;
using Gas.Model.SalesManagement;
using Gas.Services.SalesManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.CylinderIndicativePriceFeatures.CommandHandler
{
    public record AddCylinderIndicativePriceCommand(AddCylinderIndicativePriceModel Request) : IRequest<Result<QueryResEntity>>;

    internal class AddCylinderIndicativePriceCommandHandler : IRequestHandler<AddCylinderIndicativePriceCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public AddCylinderIndicativePriceCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(AddCylinderIndicativePriceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var req = _mapper.Map<InsCylinderIndicativePriceModel>(request.Request);
                var resp = new CylinderIndicativePriceService().AddCylinderIndicativePrice(req);
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

using AutoMapper;
using Gas.Domain.Entities;
using Gas.Model.SalesManagement;
using Gas.Services.SalesManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.AccessoryIndicativePriceFeatures.CommandHandler
{
    public record AddAccessoryIndicativePriceCommand(AddAccessoryIndicativePriceModel Request) : IRequest<Result<QueryResEntity>>;

    internal class AddAccessoryIndicativePriceCommandHandler : IRequestHandler<AddAccessoryIndicativePriceCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public AddAccessoryIndicativePriceCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(AddAccessoryIndicativePriceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var req = _mapper.Map<InsAccessoryIndicativePriceModel>(request.Request);
                var resp = new AccessoryIndicativePriceService().AddAccessoryIndicativePrice(req);
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

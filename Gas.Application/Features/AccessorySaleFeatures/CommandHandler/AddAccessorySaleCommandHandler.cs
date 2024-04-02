using AutoMapper;
using Gas.Domain.Entities;
using Gas.Model.SalesManagement;
using Gas.Services.SalesManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.AccessorySaleFeatures.CommandHandler
{
    public record AddAccessorySaleCommand(AddAccessorySaleModel Request) : IRequest<Result<QueryResEntity>>;

    internal class AddAccessorySaleCommandHandler : IRequestHandler<AddAccessorySaleCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public AddAccessorySaleCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(AddAccessorySaleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var req = _mapper.Map<InsAccessorySaleModel>(request.Request);
                var resp = new AccessorySaleService().AddAccessorySale(req);
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

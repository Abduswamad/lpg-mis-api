using AutoMapper;
using Gas.Domain.Entities;
using Gas.Model.SalesManagement;
using Gas.Services.SalesManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.AccessorySaleFeatures.CommandHandler
{
    public record AddAccessorySalesWithItemCommand(AddAccessorySaleWithItemModel Request) : IRequest<Result<QueryResEntity>>;

    internal class AddAccessorySalesWithItemCommandHandler : IRequestHandler<AddAccessorySalesWithItemCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public AddAccessorySalesWithItemCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(AddAccessorySalesWithItemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var req = _mapper.Map<InsAccessorySaleWithItemModel>(request.Request);
                var resp = new AccessorySaleService().AddAccessorySaleWithItem(req);
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

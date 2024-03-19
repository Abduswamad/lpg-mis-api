using AutoMapper;
using Gas.Domain.Entities;
using Gas.Model.StoreManagement;
using Gas.Services.StoreManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.AccessoryBatchItemFeatures.CommandHandler
{
    public record AddAccessoryBatchItemCommand(AddAccessoryBatchItemModel Request) : IRequest<Result<QueryResEntity>>;

    internal class AddAccessoryBatchItemCommandHandler : IRequestHandler<AddAccessoryBatchItemCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public AddAccessoryBatchItemCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(AddAccessoryBatchItemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var req = _mapper.Map<InsAccessoryBatchItemModel>(request.Request);
                var resp = new AccessoryBatchItemService().AddAccessoryBatchItem(req);
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

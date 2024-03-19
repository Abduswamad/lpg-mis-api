using AutoMapper;
using Gas.Domain.Entities;
using Gas.Model.StoreManagement;
using Gas.Services.StoreManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.BatchItemFeatures.CommandHandler
{
    public record AddBatchItemCommand(AddBatchItemModel Request) : IRequest<Result<QueryResEntity>>;

    internal class AddBatchItemCommandHandler : IRequestHandler<AddBatchItemCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public AddBatchItemCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(AddBatchItemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var req = _mapper.Map<InsBatchItemModel>(request.Request);
                var resp = new BatchItemService().AddBatchItem(req);
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

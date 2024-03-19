using AutoMapper;
using Gas.Domain.Entities;
using Gas.Model.StoreManagement;
using Gas.Services.StoreManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.BatchFeatures.CommandHandler
{
    public record AddBatchCommand(AddBatchModel Request) : IRequest<Result<QueryResEntity>>;

    internal class AddBatchCommandHandler : IRequestHandler<AddBatchCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public AddBatchCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(AddBatchCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var req = _mapper.Map<InsBatchModel>(request.Request);
                var resp = new BatchService().AddBatch(req);
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

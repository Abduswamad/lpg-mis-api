using AutoMapper;
using Gas.Domain.Entity.StoreManagement;
using Gas.Model.StoreManagement;
using Gas.Services.StoreManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.BatchtypeFeatures.QueryHandler
{
    public record GetBatchtypeByModalQuery(GetBatchtypeModel? rqModel) : IRequest<Result<IList<BatchtypeEntity>>>;

    internal class GetBatchtypeByModalQueryHandler : IRequestHandler<GetBatchtypeByModalQuery, Result<IList<BatchtypeEntity>>>
    {
        private readonly IMapper _mapper;
        public GetBatchtypeByModalQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<IList<BatchtypeEntity>>> Handle(GetBatchtypeByModalQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new BatchtypeService().GetBatchtype(request.rqModel);
                if (resp.Count>0)
                {
                    return await Result<IList<BatchtypeEntity>>.SuccessAsync(resp);
                }
                else
                {
                    return await Result<IList<BatchtypeEntity>>.FailureAsync("No Data Available");
                }
            }
            catch (Exception e)
            {
                return await Result<IList<BatchtypeEntity>>.FailureAsync(e.Message);
            }
        }

    }

}

using AutoMapper;
using Gas.Domain.Entities;
using Gas.Model.PublicManagement;
using Gas.Services.PublicManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.TrucktypeFeatures.CommandHandler
{
    public record AddTrucktypeCommand(AddTrucktypeModel Request) : IRequest<Result<QueryResEntity>>;

    internal class AddTrucktypeCommandHandler : IRequestHandler<AddTrucktypeCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public AddTrucktypeCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(AddTrucktypeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var req = _mapper.Map<InsTrucktypeModel>(request.Request);
                var resp = new TrucktypeService().AddTrucktype(req);
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

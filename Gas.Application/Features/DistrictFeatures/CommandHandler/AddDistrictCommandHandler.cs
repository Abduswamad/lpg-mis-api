using AutoMapper;
using Gas.Domain.Entities;
using Gas.Model.PublicManagement;
using Gas.Services.PublicManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.DistrictFeatures.CommandHandler
{
    public record AddDistrictCommand(AddDistrictModel Request) : IRequest<Result<QueryResEntity>>;

    internal class AddDistrictCommandHandler : IRequestHandler<AddDistrictCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public AddDistrictCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(AddDistrictCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var req = _mapper.Map<InsDistrictModel>(request.Request);
                var resp = new DistrictService().AddDistrict(req);
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

using AutoMapper;
using Gas.Domain.Entities;
using Gas.Model.SalesManagement;
using Gas.Services.SalesManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.CylinderSaleFeatures.CommandHandler
{
    public record AddCylinderSaleCommand(AddCylinderSaleModel Request) : IRequest<Result<QueryResEntity>>;

    internal class AddCylinderSaleCommandHandler : IRequestHandler<AddCylinderSaleCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public AddCylinderSaleCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(AddCylinderSaleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var req = _mapper.Map<InsCylinderSaleModel>(request.Request);
                var resp = new CylinderSaleService().AddCylinderSale(req);
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

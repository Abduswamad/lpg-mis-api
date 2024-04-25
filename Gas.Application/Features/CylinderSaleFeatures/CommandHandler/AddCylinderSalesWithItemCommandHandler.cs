using AutoMapper;
using Gas.Domain.Entities;
using Gas.Model.SalesManagement;
using Gas.Services.SalesManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.CylinderSaleFeatures.CommandHandler
{
    public record AddCylinderSalesWithItemCommand(AddCylinderSalesWithItemModel Request) : IRequest<Result<QueryResEntity>>;

    internal class AddCylinderSalesWithItemCommandHandler : IRequestHandler<AddCylinderSalesWithItemCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public AddCylinderSalesWithItemCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(AddCylinderSalesWithItemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var req = _mapper.Map<InsCylinderSalesWithItemModel>(request.Request);
                var resp = new CylinderSaleService().AddCylinderSaleWithItem(req);
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

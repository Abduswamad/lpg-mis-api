using AutoMapper;
using FluentValidation;
using Gas.Domain.Entities;
using Gas.Model.CompanyManagement;
using Gas.Services.CompanyManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.ShopFeatures.CommandHandler
{
    public record AddShopCommand(AddShopModel Request) : IRequest<Result<QueryResEntity>>;

    internal class AddShopCommandHandler : IRequestHandler<AddShopCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public AddShopCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(AddShopCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var req = _mapper.Map<InsShopModel>(request.Request);
                var resp = new ShopService().AddShop(req);
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

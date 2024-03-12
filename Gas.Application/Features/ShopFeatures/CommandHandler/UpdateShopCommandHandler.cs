using AutoMapper;
using FluentValidation;
using Gas.Domain.Entities;
using Gas.Model.CompanyManagement;
using Gas.Services.CompanyManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.ShopFeatures.CommandHandler
{
    public record UpdateShopCommand(UpdateShopModel Request) : IRequest<Result<QueryResEntity>>;

    internal class UpdateShopCommandHandler : IRequestHandler<UpdateShopCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public UpdateShopCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(UpdateShopCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new ShopService().UpdateShop(request.Request);
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

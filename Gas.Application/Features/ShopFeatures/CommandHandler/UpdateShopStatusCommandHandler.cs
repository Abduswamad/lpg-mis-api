using AutoMapper;
using FluentValidation;
using Gas.Domain.Entities;
using Gas.Model.CompanyManagement;
using Gas.Services.CompanyManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.ShopFeatures.CommandHandler
{
    public record UpdateShopStatusCommand(RequestShopStatusModel Request) : IRequest<Result<QueryResEntity>>;

    internal class UpdateShopStatusCommandHandler : IRequestHandler<UpdateShopStatusCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public UpdateShopStatusCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(UpdateShopStatusCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new ShopService().UpdateStatusShop(request.Request);
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

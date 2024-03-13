using AutoMapper;
using FluentValidation;
using Gas.Domain.Entities;
using Gas.Model.PublicManagement;
using Gas.Services.PublicManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.AccessorybrandFeatures.CommandHandler
{
    public record UpdateAccessorybrandStatusCommand(RequestAccessorybrandStatusModel Request) : IRequest<Result<QueryResEntity>>;

    internal class UpdateAccessorybrandStatusCommandHandler : IRequestHandler<UpdateAccessorybrandStatusCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public UpdateAccessorybrandStatusCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(UpdateAccessorybrandStatusCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new AccessorybrandService().UpdateStatusAccessorybrand(request.Request);
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

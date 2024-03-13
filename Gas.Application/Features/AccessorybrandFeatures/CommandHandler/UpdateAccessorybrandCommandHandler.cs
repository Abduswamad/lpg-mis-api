using AutoMapper;
using FluentValidation;
using Gas.Domain.Entities;
using Gas.Model.PublicManagement;
using Gas.Services.PublicManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.AccessorybrandFeatures.CommandHandler
{
    public record UpdateAccessorybrandCommand(UpdateAccessorybrandModel Request) : IRequest<Result<QueryResEntity>>;

    internal class UpdateAccessorybrandCommandHandler : IRequestHandler<UpdateAccessorybrandCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public UpdateAccessorybrandCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(UpdateAccessorybrandCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new AccessorybrandService().UpdateAccessorybrand(request.Request);
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

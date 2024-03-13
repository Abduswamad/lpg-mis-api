using AutoMapper;
using FluentValidation;
using Gas.Domain.Entities;
using Gas.Model.PublicManagement;
using Gas.Services.PublicManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.WardFeatures.CommandHandler
{
    public record UpdateWardCommand(UpdateWardModel Request) : IRequest<Result<QueryResEntity>>;

    internal class UpdateWardCommandHandler : IRequestHandler<UpdateWardCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public UpdateWardCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(UpdateWardCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new WardService().UpdateWard(request.Request);
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

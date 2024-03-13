using AutoMapper;
using FluentValidation;
using Gas.Domain.Entities;
using Gas.Model.PublicManagement;
using Gas.Services.PublicManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.CommonstreetFeatures.CommandHandler
{
    public record UpdateCommonstreetCommand(UpdateCommonstreetModel Request) : IRequest<Result<QueryResEntity>>;

    internal class UpdateCommonstreetCommandHandler : IRequestHandler<UpdateCommonstreetCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public UpdateCommonstreetCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(UpdateCommonstreetCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new CommonstreetService().UpdateCommonstreet(request.Request);
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

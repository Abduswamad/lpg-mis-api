using AutoMapper;
using FluentValidation;
using Gas.Domain.Entities;
using Gas.Model.PublicManagement;
using Gas.Services.PublicManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.GenderFeatures.CommandHandler
{
    public record UpdateGenderCommand(UpdateGenderModel Request) : IRequest<Result<QueryResEntity>>;

    internal class UpdateGenderCommandHandler : IRequestHandler<UpdateGenderCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public UpdateGenderCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(UpdateGenderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new GenderService().UpdateGender(request.Request);
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

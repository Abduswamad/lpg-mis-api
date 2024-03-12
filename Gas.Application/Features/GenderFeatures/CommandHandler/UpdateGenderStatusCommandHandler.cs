using AutoMapper;
using FluentValidation;
using Gas.Domain.Entities;
using Gas.Model.PublicManagement;
using Gas.Services.PublicManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.GenderFeatures.CommandHandler
{
    public record UpdateGenderStatusCommand(RequestGenderStatusModel Request) : IRequest<Result<QueryResEntity>>;

    internal class UpdateGenderStatusCommandHandler : IRequestHandler<UpdateGenderStatusCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public UpdateGenderStatusCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(UpdateGenderStatusCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new GenderService().UpdateStatusGender(request.Request);
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

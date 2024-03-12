using AutoMapper;
using Gas.Domain.Entities;
using Gas.Model.PublicManagement;
using Gas.Services.PublicManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.GenderFeatures.CommandHandler
{
    public record AddGenderCommand(AddGenderModel Request) : IRequest<Result<QueryResEntity>>;

    internal class AddGenderCommandHandler : IRequestHandler<AddGenderCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public AddGenderCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(AddGenderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var req = _mapper.Map<InsGenderModel>(request.Request);
                var resp = new GenderService().AddGender(req);
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

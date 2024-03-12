using AutoMapper;
using FluentValidation;
using Gas.Domain.Entities;
using Gas.Model.CompanyManagement;
using Gas.Services.CompanyManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.DepoFeatures.CommandHandler
{
    public record AddDepoCommand(AddDepoModel Request) : IRequest<Result<QueryResEntity>>;

    internal class AddDepoCommandHandler : IRequestHandler<AddDepoCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public AddDepoCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(AddDepoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var req = _mapper.Map<InsDepoModel>(request.Request);
                var resp = new DepoService().AddDepo(req);
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

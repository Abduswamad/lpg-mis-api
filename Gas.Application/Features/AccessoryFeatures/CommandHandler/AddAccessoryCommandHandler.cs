using AutoMapper;
using FluentValidation;
using Gas.Domain.Entities;
using Gas.Model.CompanyManagement;
using Gas.Services.CompanyManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.AccessoryFeatures.CommandHandler
{
    public record AddAccessoryCommand(AddAccessoryModel Request) : IRequest<Result<QueryResEntity>>;

    internal class AddAccessoryCommandHandler : IRequestHandler<AddAccessoryCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public AddAccessoryCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(AddAccessoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var req = _mapper.Map<InsAccessoryModel>(request.Request);
                var resp = new AccessoryService().AddAccessory(req);
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

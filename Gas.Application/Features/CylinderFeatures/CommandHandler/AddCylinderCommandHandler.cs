using AutoMapper;
using FluentValidation;
using Gas.Domain.Entities;
using Gas.Model.CompanyManagement;
using Gas.Services.CompanyManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.CylinderFeatures.CommandHandler
{
    public record AddCylinderCommand(AddCylinderModel Request) : IRequest<Result<QueryResEntity>>;

    internal class AddCylinderCommandHandler : IRequestHandler<AddCylinderCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public AddCylinderCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(AddCylinderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var req = _mapper.Map<InsCylinderModel>(request.Request);
                var resp = new CylinderService().AddCylinder(req);
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

using AutoMapper;
using FluentValidation;
using Gas.Domain.Entities;
using Gas.Model.CompanyManagement;
using Gas.Services.CompanyManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.CylinderFeatures.CommandHandler
{
    public record UpdateCylinderCommand(UpdateCylinderModel Request) : IRequest<Result<QueryResEntity>>;

    internal class UpdateCylinderCommandHandler : IRequestHandler<UpdateCylinderCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public UpdateCylinderCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(UpdateCylinderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new CylinderService().UpdateCylinder(request.Request);
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

using AutoMapper;
using FluentValidation;
using Gas.Domain.Entities;
using Gas.Model.PublicManagement;
using Gas.Services.PublicManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.CylindercategoryFeatures.CommandHandler
{
    public record UpdateCylindercategoryStatusCommand(RequestCylindercategoryStatusModel Request) : IRequest<Result<QueryResEntity>>;

    internal class UpdateCylindercategoryStatusCommandHandler : IRequestHandler<UpdateCylindercategoryStatusCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public UpdateCylindercategoryStatusCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(UpdateCylindercategoryStatusCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new CylindercategoryService().UpdateStatusCylindercategory(request.Request);
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

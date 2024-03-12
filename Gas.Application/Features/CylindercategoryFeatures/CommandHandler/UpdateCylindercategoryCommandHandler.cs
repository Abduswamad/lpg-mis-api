using AutoMapper;
using FluentValidation;
using Gas.Domain.Entities;
using Gas.Model.PublicManagement;
using Gas.Services.PublicManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.CylindercategoryFeatures.CommandHandler
{
    public record UpdateCylindercategoryCommand(UpdateCylindercategoryModel Request) : IRequest<Result<QueryResEntity>>;

    internal class UpdateCylindercategoryCommandHandler : IRequestHandler<UpdateCylindercategoryCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public UpdateCylindercategoryCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(UpdateCylindercategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new CylindercategoryService().UpdateCylindercategory(request.Request);
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

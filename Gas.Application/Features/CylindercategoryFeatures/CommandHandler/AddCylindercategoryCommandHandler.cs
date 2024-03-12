using AutoMapper;
using Gas.Domain.Entities;
using Gas.Model.PublicManagement;
using Gas.Services.PublicManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.CylindercategoryFeatures.CommandHandler
{
    public record AddCylindercategoryCommand(AddCylindercategoryModel Request) : IRequest<Result<QueryResEntity>>;

    internal class AddCylindercategoryCommandHandler : IRequestHandler<AddCylindercategoryCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public AddCylindercategoryCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(AddCylindercategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var req = _mapper.Map<InsCylindercategoryModel>(request.Request);
                var resp = new CylindercategoryService().AddCylindercategory(req);
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

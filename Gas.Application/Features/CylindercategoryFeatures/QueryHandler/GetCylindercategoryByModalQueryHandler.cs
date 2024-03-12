using AutoMapper;
using MediatR;
using Gas.Domain.Entities;
using Gas.Utils;
using Gas.Domain.Entity.PublicManagement;
using Gas.Services.PublicManagement;
using Gas.Model.PublicManagement;

namespace Gas.Application.Features.CylindercategoryFeatures.QueryHandler
{
    public record GetCylindercategoryByModalQuery(GetCylindercategoryModel? rqModel) : IRequest<Result<IList<CylindercategoryEntity>>>;

    internal class GetCylindercategoryByModalQueryHandler : IRequestHandler<GetCylindercategoryByModalQuery, Result<IList<CylindercategoryEntity>>>
    {
        private readonly IMapper _mapper;
        public GetCylindercategoryByModalQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<IList<CylindercategoryEntity>>> Handle(GetCylindercategoryByModalQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new CylindercategoryService().GetCylindercategory(request.rqModel);
                if (resp.Count>0)
                {
                    var response = _mapper.Map<List<CylindercategoryEntity>>(resp);
                    return await Result<IList<CylindercategoryEntity>>.SuccessAsync(response);
                }
                else
                {
                    return await Result<IList<CylindercategoryEntity>>.FailureAsync("No Data Available");
                }
            }
            catch (Exception e)
            {
                return await Result<IList<CylindercategoryEntity>>.FailureAsync(e.Message);
            }
        }

    }

}

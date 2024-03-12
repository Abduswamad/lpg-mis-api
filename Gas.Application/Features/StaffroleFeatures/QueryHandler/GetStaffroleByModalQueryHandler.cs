using AutoMapper;
using MediatR;
using Gas.Domain.Entities;
using Gas.Utils;
using Gas.Domain.Entity.CompanyManagement;
using Gas.Services.CompanyManagement;
using Gas.Model.CompanyManagement;

namespace Gas.Application.Features.StaffroleFeatures.QueryHandler
{
    public record GetStaffroleByModalQuery(GetStaffroleModel? rqModel) : IRequest<Result<IList<StaffRoleEntity>>>;

    internal class GetStaffroleByModalQueryHandler : IRequestHandler<GetStaffroleByModalQuery, Result<IList<StaffRoleEntity>>>
    {
        private readonly IMapper _mapper;
        public GetStaffroleByModalQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<IList<StaffRoleEntity>>> Handle(GetStaffroleByModalQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new StaffroleService().GetStaffrole(request.rqModel);
                if (resp.Count>0)
                {
                    var response = _mapper.Map<List<StaffRoleEntity>>(resp);
                    return await Result<IList<StaffRoleEntity>>.SuccessAsync(response);
                }
                else
                {
                    return await Result<IList<StaffRoleEntity>>.FailureAsync("No Data Available");
                }
            }
            catch (Exception e)
            {
                return await Result<IList<StaffRoleEntity>>.FailureAsync(e.Message);
            }
        }

    }

}

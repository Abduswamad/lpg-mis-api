using AutoMapper;
using Gas.Domain.Entity.CompanyManagement;
using Gas.Services.CompanyManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.StafftypeFeatures.QueryHandler
{
    public record GetStafftypeQuery() : IRequest<Result<IList<StaffTypeEntity>>>;

    internal class GetStafftypeQueryHandler : IRequestHandler<GetStafftypeQuery, Result<IList<StaffTypeEntity>>>
    {
        private readonly IMapper _mapper;
        public GetStafftypeQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<IList<StaffTypeEntity>>> Handle(GetStafftypeQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new StafftypeService().GetStafftype();
                if (resp.Count>0)
                {
                    return await Result<IList<StaffTypeEntity>>.SuccessAsync(resp);
                }
                else
                {
                    return await Result<IList<StaffTypeEntity>>.FailureAsync("No Data Available");
                }
            }
            catch (Exception e)
            {
                return await Result<IList<StaffTypeEntity>>.FailureAsync(e.Message);
            }
        }

    }

}

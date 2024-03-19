using AutoMapper;
using MediatR;
using Gas.Domain.Entities;
using Gas.Utils;
using Gas.Domain.Entity.PublicManagement;
using Gas.Services.PublicManagement;
using Gas.Model.PublicManagement;

namespace Gas.Application.Features.GenderFeatures.QueryHandler
{
    public record GetGenderByModalQuery(GetGenderModel? rqModel) : IRequest<Result<IList<GenderEntity>>>;

    internal class GetGenderByModalQueryHandler : IRequestHandler<GetGenderByModalQuery, Result<IList<GenderEntity>>>
    {
       
        public async Task<Result<IList<GenderEntity>>> Handle(GetGenderByModalQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new GenderService().GetGender(request.rqModel);
                if (resp.Count>0)
                {
                    return await Result<IList<GenderEntity>>.SuccessAsync(resp);
                }
                else
                {
                    return await Result<IList<GenderEntity>>.FailureAsync("No Data Available");
                }
            }
            catch (Exception e)
            {
                return await Result<IList<GenderEntity>>.FailureAsync(e.Message);
            }
        }

    }

}

﻿using AutoMapper;
using MediatR;
using Gas.Domain.Entities;
using Gas.Utils;
using Gas.Domain.Entity.PublicManagement;
using Gas.Services.PublicManagement;
using Gas.Model.PublicManagement;

namespace Gas.Application.Features.RegionFeatures.QueryHandler
{
    public record GetRegionByModalQuery(GetRegionModel? rqModel) : IRequest<Result<IList<RegionEntity>>>;

    internal class GetRegionByModalQueryHandler : IRequestHandler<GetRegionByModalQuery, Result<IList<RegionEntity>>>
    {
        private readonly IMapper _mapper;
        public GetRegionByModalQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<IList<RegionEntity>>> Handle(GetRegionByModalQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new RegionService().GetRegion(request.rqModel);
                if (resp.Count>0)
                {
                    var response = _mapper.Map<List<RegionEntity>>(resp);
                    return await Result<IList<RegionEntity>>.SuccessAsync(response);
                }
                else
                {
                    return await Result<IList<RegionEntity>>.FailureAsync("No Data Available");
                }
            }
            catch (Exception e)
            {
                return await Result<IList<RegionEntity>>.FailureAsync(e.Message);
            }
        }

    }

}

﻿using AutoMapper;
using MediatR;
using Gas.Domain.Entities;
using Gas.Utils;
using Gas.Domain.Entity.PublicManagement;
using Gas.Services.PublicManagement;
using Gas.Model.PublicManagement;

namespace Gas.Application.Features.AccessorybrandFeatures.QueryHandler
{
    public record GetAccessorybrandByModalQuery(GetAccessorybrandModel? rqModel) : IRequest<Result<IList<AccessorybrandEntity>>>;

    internal class GetAccessorybrandByModalQueryHandler : IRequestHandler<GetAccessorybrandByModalQuery, Result<IList<AccessorybrandEntity>>>
    {
        public async Task<Result<IList<AccessorybrandEntity>>> Handle(GetAccessorybrandByModalQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new AccessorybrandService().GetAccessorybrand(request.rqModel);
                if (resp.Count>0)
                {
                    return await Result<IList<AccessorybrandEntity>>.SuccessAsync(resp);
                }
                else
                {
                    return await Result<IList<AccessorybrandEntity>>.FailureAsync("No Data Available");
                }
            }
            catch (Exception e)
            {
                return await Result<IList<AccessorybrandEntity>>.FailureAsync(e.Message);
            }
        }

    }

}

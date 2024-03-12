﻿using AutoMapper;
using FluentValidation;
using Gas.Domain.Entities;
using Gas.Model.CompanyManagement;
using Gas.Services.CompanyManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.DepoFeatures.CommandHandler
{
    public record UpdateDepoCommand(UpdateDepoModel Request) : IRequest<Result<QueryResEntity>>;

    internal class UpdateDepoCommandHandler : IRequestHandler<UpdateDepoCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public UpdateDepoCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(UpdateDepoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new DepoService().UpdateDepo(request.Request);
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

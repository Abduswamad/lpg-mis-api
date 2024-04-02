using AutoMapper;
using FluentValidation;
using Gas.Domain.Entities;
using Gas.Model.CompanyManagement;
using Gas.Services.CompanyManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.AccessoryFeatures.CommandHandler
{
    public record UpdateAccessoryStatusCommand(RequestAccessoryStatusModel Request) : IRequest<Result<QueryResEntity>>;

    internal class UpdateAccessoryStatusCommandHandler : IRequestHandler<UpdateAccessoryStatusCommand, Result<QueryResEntity>>
    {
        public async Task<Result<QueryResEntity>> Handle(UpdateAccessoryStatusCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new AccessoryService().UpdateStatusAccessory(request.Request);
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

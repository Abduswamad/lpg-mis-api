using AutoMapper;
using FluentValidation;
using Gas.Domain.Entities;
using Gas.Model.CompanyManagement;
using Gas.Services.CompanyManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.TruckFeatures.CommandHandler
{
    public record UpdateTruckCommand(UpdateTruckModel Request) : IRequest<Result<QueryResEntity>>;

    internal class UpdateTruckCommandHandler : IRequestHandler<UpdateTruckCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public UpdateTruckCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(UpdateTruckCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new TruckService().UpdateTruck(request.Request);
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

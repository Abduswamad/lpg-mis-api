using AutoMapper;
using FluentValidation;
using Gas.Domain.Entities;
using Gas.Model.CompanyManagement;
using Gas.Services.CompanyManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.UserFeatures.CommandHandler
{
    public record UpdateStaffCommand(UpdateStaffModel Request) : IRequest<Result<QueryResEntity>>;

    internal class UpdateStaffCommandHandler : IRequestHandler<UpdateStaffCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public UpdateStaffCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(UpdateStaffCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new StaffService().UpdateStaff(request.Request);
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

using AutoMapper;
using FluentValidation;
using Gas.Domain.Entities;
using Gas.Model.CompanyManagement;
using Gas.Services.CompanyManagement;
using Gas.Utils;
using MediatR;

namespace Gas.Application.Features.UserFeatures.CommandHandler
{
    public record AddStaffCommand(AddStaffModel Request) : IRequest<Result<QueryResEntity>>;

    internal class AddStaffCommandHandler : IRequestHandler<AddStaffCommand, Result<QueryResEntity>>
    {
        private readonly IMapper _mapper;
        public AddStaffCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<QueryResEntity>> Handle(AddStaffCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var req = _mapper.Map<InsStaffModel>(request.Request);
                var resp = new StaffService().AddStaff(req);
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

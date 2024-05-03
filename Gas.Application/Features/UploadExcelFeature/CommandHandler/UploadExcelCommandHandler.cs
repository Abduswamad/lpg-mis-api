using Gas.Domain.Entities;
using Gas.Services;
using Gas.Utils;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Gas.Application.Features.UploadExcelFeatures.CommandHandler
{
    public record UploadExcelCommand(IFormFile File,int SuperDelaerId) : IRequest<Result<QueryResEntity>>;

    internal class UploadExcelCommandHandler : IRequestHandler<UploadExcelCommand, Result<QueryResEntity>>
    {
        public async Task<Result<QueryResEntity>> Handle(UploadExcelCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resp = new UploadExcelService().UpLoadExcelIForm(request.File, request.SuperDelaerId);
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

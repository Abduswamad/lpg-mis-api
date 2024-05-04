using Gas.Application.Features.UploadExcelFeatures.CommandHandler;
using Gas.Common;
using Gas.Domain.Entities;
using Gas.Utils;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Gas.WebAPI.Controllers.v1.GMS.Controllers
{
    /// <summary>
    /// API Endpoint Controller for UploadExcel Management.
    /// </summary>
    /// <remarks>
    /// API Controller Instance for UploadExcel Management.
    /// </remarks>
    /// <param name="mediator">The mediator instance used for handling communication between components.</param>
    [Authorize()]
    [Route("api/v{version:apiversion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class UploadExcelManagementController(IMediator mediator) : ControllerBase
    {
        /// <summary>
        /// The mediator instance used for handling communication between components.
        /// </summary>
        private readonly IMediator _mediator = mediator;

        #region UploadExcel

        /// <summary>
        /// API Endpoint for UploadExcel.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with UploadExcel Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPost("UploadExcel")]
        [Restrict(AllowVerbs = "POST")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<QueryResEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Unauthorized)]
        [AllowAnonymous]
        public async Task<IActionResult> UploadSuperDealerExcel(IFormFile file, int SuperDelaerId)
        {
            try
            {
                var result = await _mediator.Send(new UploadExcelCommand(file, SuperDelaerId));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion UploadExcel

    }
}

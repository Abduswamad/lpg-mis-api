using Gas.Application.Features.CylinderstatusFeatures.QueryHandler;
using Gas.Common;
using Gas.Domain.Entity.StoreManagement;
using Gas.Model.StoreManagement;
using Gas.Utils;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Gas.WebAPI.Controllers.v1.GMS.Controllers
{
    /// <summary>
    /// API Endpoint Controller for Cylinderstatus Management.
    /// </summary>
    /// <remarks>
    /// API Controller Instance for Cylinderstatus Management.
    /// </remarks>
    /// <param name="mediator">The mediator instance used for handling communication between components.</param>
    [Authorize()]
    [Route("api/v{version:apiversion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class CylinderstatusManagementController(IMediator mediator) : ControllerBase
    {
        /// <summary>
        /// The mediator instance used for handling communication between components.
        /// </summary>
        private readonly IMediator _mediator = mediator;

        #region Cylinderstatus

        /// <summary>
        /// API Endpoint for Displaying All Cylinderstatus.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with Cylinderstatus Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpGet("GetCylinderstatus")]
        [Restrict(AllowVerbs = "GET")]
        [Produces("application/json")]        
        [ProducesResponseType(typeof(Result<IList<CylinderstatusEntity>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetCylinderstatus()
        {
            try
            {
                var result = await _mediator.Send(new GetCylinderstatusQuery());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// API Endpoint for Displaying Cylinderstatus by modal.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with Cylinderstatus Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPost("GetCylinderstatusByModel")]
        [Restrict(AllowVerbs = "POST")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<IList<CylinderstatusEntity>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetCylinderstatus(GetCylinderstatusModel? rqModel)
        {
            try
            {
                var result = await _mediator.Send(new GetCylinderstatusByModalQuery(rqModel));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        #endregion Cylinderstatus

    }
}

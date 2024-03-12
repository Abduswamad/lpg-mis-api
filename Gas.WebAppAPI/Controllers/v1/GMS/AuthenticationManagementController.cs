using Gas.Application.Features.AccountFeatures.CommandHandler;
using Gas.Common;
using Gas.Domain.Entity.CompanyManagement;
using Gas.Model.CompanyManagement;
using Gas.Utils;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Gas.WebAPI.Controllers.v1.GMS.Controllers
{
    /// <summary>
    /// API Endpoint Controller for Staff Management.
    /// </summary>
    [Route("api/v{version:apiversion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AuthenticationManagementController : ControllerBase
    {
        /// <summary>
        /// The mediator instance used for handling communication between components.
        /// </summary>
        private readonly IMediator _mediator;
        public IConfiguration _configuration;

        /// <summary>
        /// API Controller Instance for Staff Management.
        /// </summary>
        /// <param name="mediator">The mediator instance used for handling communication between components.</param>
        public AuthenticationManagementController(IConfiguration config,IMediator mediator)
        {
            _mediator = mediator;
            _configuration = config;
        }

        #region Authentication

        /// <summary>
        /// API Endpoint for Staff Login.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with Staff Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPost("StaffLogin")]
        [Restrict(AllowVerbs = "POST")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<StaffLoginEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> StaffLogin(RequestStaffLoginEntity rqModel)
        {
            try
            {
                var result = await _mediator.Send(new StaffLoginCommand(rqModel));                
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// API Endpoint for Staff Login.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with Staff Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPost("StaffToken")]
        [Restrict(AllowVerbs = "POST")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(StaffTokenEntity), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> StaffToken(RequestStaffLoginEntity rqModel)
        {
            try
            {
                var result = await _mediator.Send(new StaffLoginTokenCommand(rqModel));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        #endregion Authentication

    }
}

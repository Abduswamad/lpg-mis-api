using Gas.Application.Features.AccountFeatures.CommandHandler;
using Gas.Application.Features.StaffFeatures.CommandHandler;
using Gas.Common;
using Gas.Domain.Entities;
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
    public class AccountManagementController : ControllerBase
    {
        /// <summary>
        /// The mediator instance used for handling communication between components.
        /// </summary>
        private readonly IMediator _mediator;

        /// <summary>
        /// API Controller Instance for Staff Management.
        /// </summary>
        /// <param name="mediator">The mediator instance used for handling communication between components.</param>
        public AccountManagementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Account

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
        public async Task<IActionResult> StaffLogin(RequestStaffLoginEntity rqModel)
        {
            try
            {
                var result = await _mediator.Send(new StaffLoginCommand(rqModel));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// API Endpoint for Changing Staff Password.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with Staff Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPatch("ChangeStaffPassword")]
        [Restrict(AllowVerbs = "PATCH")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<QueryResEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ChangeStaffPassword(RequestStaffpassChangeModel rqModel)
        {
            try
            {
               
                if (rqModel != null)
                {

                    // If the model is valid or null, proceed with the command
                    var result = await _mediator.Send(new StaffChangePasswordCommand(rqModel));
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Staff Request Model is Invalid");
                }
                
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// API Endpoint for Reseting Password.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with Staff Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPatch("ResetStaffPassword")]
        [Restrict(AllowVerbs = "PATCH")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<QueryResEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ResetStaffPassword(RequestStaffResetpassChangeModel rqModel)
        {
            try
            {

                if (rqModel != null)
                {

                    // If the model is valid or null, proceed with the command
                    var result = await _mediator.Send(new StaffResetPasswordCommand(rqModel));
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Staff Request Model is Invalid");
                }

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        /// <summary>
        /// API Endpoint for Reseting Password.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with Staff Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPatch("ChangeStaffPasswordOnLogin")]
        [Restrict(AllowVerbs = "PATCH")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<QueryResEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ChangeStaffPasswordOnLogin(RequestStaffpassChangeModel rqModel)
        {
            try
            {

                if (rqModel != null)
                {

                    // If the model is valid or null, proceed with the command
                    var result = await _mediator.Send(new StaffChangePasswordOnLoginCommand(rqModel));
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Staff Request Model is Invalid");
                }

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// API Endpoint for Update Staff Status.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with Staff Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPatch("UpdateStaffStatus")]
        [Restrict(AllowVerbs = "PATCH")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<QueryResEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateStaffStatus(RequestStaffStatusModel rqModel)
        {
            try
            {

                if (rqModel != null)
                {

                    // If the model is valid or null, proceed with the command
                    var result = await _mediator.Send(new UpdateStaffStatusCommand(rqModel));
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Staff Request Model is Invalid");
                }

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        #endregion Account

    }
}

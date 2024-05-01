using Gas.Application.Features.StaffFeatures.CommandHandler;
using Gas.Application.Features.StaffFeatures.QueryHandler;
using Gas.Application.Features.StaffFeatures.Validator;
using Gas.Common;
using Gas.Domain.Entities;
using Gas.Domain.Entity.CompanyManagement;
using Gas.Model.CompanyManagement;
using Gas.Utils;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Gas.WebAPI.Controllers.v1.GMS.Controllers
{
    /// <summary>
    /// API Endpoint Controller for Staff Management.
    /// </summary>
    /// <remarks>
    /// API Controller Instance for Staff Management.
    /// </remarks>
    /// <param name="mediator">The mediator instance used for handling communication between components.</param>
    [Authorize()]
    [Route("api/v{version:apiversion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class StaffManagementController(IMediator mediator) : ControllerBase
    {
        /// <summary>
        /// The mediator instance used for handling communication between components.
        /// </summary>
        private readonly IMediator _mediator = mediator;

        #region Staff

        /// <summary>
        /// API Endpoint for Displaying All Staff.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with Staff Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpGet("GetStaff")]
        [Restrict(AllowVerbs = "GET")]
        [Produces("application/json")]        
        [ProducesResponseType(typeof(Result<IList<StaffEntity>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetStaff()
        {
            try
            {
                var result = await _mediator.Send(new GetStaffQuery());
                var superDealerId = User.GetSuperDealerId();
                if (result.Data.Count > 0)
                {
                    result.Data = result.Data.Where(x => x.Super_dealer_id == superDealerId).ToList();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// API Endpoint for Displaying Staff by modal.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with Staff Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPost("GetStaffByModel")]
        [Restrict(AllowVerbs = "POST")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<IList<StaffEntity>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetStaff(GetStaffModel? rqModel)
        {
            try
            {
                var result = await _mediator.Send(new GetStaffByModalQuery(rqModel));
                var superDealerId = User.GetSuperDealerId();
                if (result.Data.Count > 0)
                {
                    result.Data = result.Data.Where(x => x.Super_dealer_id == superDealerId).ToList();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// API Endpoint for Adding Staff.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with Staff Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPost("AddStaff")]
        [Restrict(AllowVerbs = "POST")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<QueryResEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> AddStaff(AddStaffModel rqModel)
        {
            try
            {               
                if (rqModel != null)
                {
                    // Validate the model
                    var validator = new AddStaffValidator(); // Assuming you have a validator for AddStaffModel
                    var validationResult = await validator.ValidateAsync(rqModel);

                    // Check if validation failed
                    if (!validationResult.IsValid)
                    {
                        return BadRequest(validationResult.Errors);
                    }

                    // If the model is valid or null, proceed with the command
                    var result = await _mediator.Send(new AddStaffCommand(rqModel));
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Staff Request Model is Invalid");
                }
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// API Endpoint for Update Staff.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with Staff Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPut("UpdateStaff")]
        [Restrict(AllowVerbs = "PUT")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<QueryResEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> UpdateStaff(UpdateStaffModel rqModel)
        {
            try
            {
                if (rqModel != null)
                {
                    // Validate the model
                    var validator = new UpdateStaffValidator(); // Assuming you have a validator for AddStaffModel
                    var validationResult = await validator.ValidateAsync(rqModel);

                    // Check if validation failed
                    if (!validationResult.IsValid)
                    {
                        return BadRequest(validationResult.Errors);
                    }

                    // If the model is valid or null, proceed with the command
                    var result = await _mediator.Send(new UpdateStaffCommand(rqModel));
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Staff Request Model is Invalid");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
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
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Unauthorized)]
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
                return BadRequest(ex.Message);
            }
        }

        #endregion Staff

    }
}

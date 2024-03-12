using Gas.Application.Features.StaffroleFeatures.CommandHandler;
using Gas.Application.Features.StaffroleFeatures.QueryHandler;
using Gas.Application.Features.StaffroleFeatures.Validator;
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
    /// API Endpoint Controller for Staffrole Management.
    /// </summary>
    [Route("api/v{version:apiversion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class StaffroleManagementController : ControllerBase
    {
        /// <summary>
        /// The mediator instance used for handling communication between components.
        /// </summary>
        private readonly IMediator _mediator;

        /// <summary>
        /// API Controller Instance for Staffrole Management.
        /// </summary>
        /// <param name="mediator">The mediator instance used for handling communication between components.</param>
        public StaffroleManagementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Staffrole

        /// <summary>
        /// API Endpoint for Displaying All Staffrole.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with Staffrole Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpGet("GetStaffrole")]
        [Restrict(AllowVerbs = "GET")]
        [Produces("application/json")]        
        [ProducesResponseType(typeof(Result<IList<StaffRoleEntity>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetStaffrole()
        {
            try
            {
                var result = await _mediator.Send(new GetStaffroleQuery());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// API Endpoint for Displaying Staffrole by modal.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with Staffrole Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPost("GetStaffroleByModel")]
        [Restrict(AllowVerbs = "POST")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<IList<StaffRoleEntity>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetStaffrole(GetStaffroleModel? rqModel)
        {
            try
            {
                var result = await _mediator.Send(new GetStaffroleByModalQuery(rqModel));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// API Endpoint for Adding Staffrole.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with Staffrole Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPost("AddStaffrole")]
        [Restrict(AllowVerbs = "POST")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<QueryResEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> AddStaffrole(AddStaffroleModel rqModel)
        {
            try
            {
               
                if (rqModel != null)
                {
                    // Validate the model
                    var validator = new AddStaffroleValidator(); // Assuming you have a validator for AddStaffroleModel
                    var validationResult = await validator.ValidateAsync(rqModel);

                    // Check if validation failed
                    if (!validationResult.IsValid)
                    {
                        return BadRequest(validationResult.Errors);
                    }

                    // If the model is valid or null, proceed with the command
                    var result = await _mediator.Send(new AddStaffroleCommand(rqModel));
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Staffrole Request Model is Invalid");
                }
                
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// API Endpoint for Update Staffrole.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with Staffrole Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPut("UpdateStaffrole")]
        [Restrict(AllowVerbs = "PUT")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<QueryResEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateStaffrole(UpdateStaffroleModel rqModel)
        {
            try
            {

                if (rqModel != null)
                {
                    // Validate the model
                    var validator = new UpdateStaffroleValidator(); // Assuming you have a validator for AddStaffroleModel
                    var validationResult = await validator.ValidateAsync(rqModel);

                    // Check if validation failed
                    if (!validationResult.IsValid)
                    {
                        return BadRequest(validationResult.Errors);
                    }

                    // If the model is valid or null, proceed with the command
                    var result = await _mediator.Send(new UpdateStaffroleCommand(rqModel));
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Staffrole Request Model is Invalid");
                }

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// API Endpoint for Update Staffrole Status.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with Staffrole Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPatch("UpdateStaffroleStatus")]
        [Restrict(AllowVerbs = "PATCH")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<QueryResEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateStaffroleStatus(RequestStaffroleStatusModel rqModel)
        {
            try
            {

                if (rqModel != null)
                {

                    // If the model is valid or null, proceed with the command
                    var result = await _mediator.Send(new UpdateStaffroleStatusCommand(rqModel));
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Staffrole Request Model is Invalid");
                }

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        #endregion Staffrole

    }
}

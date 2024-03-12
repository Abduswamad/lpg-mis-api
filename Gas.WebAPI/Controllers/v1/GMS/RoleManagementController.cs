using Gas.Application.Features.RoleFeatures.CommandHandler;
using Gas.Application.Features.RoleFeatures.QueryHandler;
using Gas.Application.Features.RoleFeatures.Validator;
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
    /// API Endpoint Controller for Role Management.
    /// </summary>
    [Route("api/v{version:apiversion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class RoleManagementController : ControllerBase
    {
        /// <summary>
        /// The mediator instance used for handling communication between components.
        /// </summary>
        private readonly IMediator _mediator;

        /// <summary>
        /// API Controller Instance for Role Management.
        /// </summary>
        /// <param name="mediator">The mediator instance used for handling communication between components.</param>
        public RoleManagementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Role

        /// <summary>
        /// API Endpoint for Displaying All Role.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with Role Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpGet("GetRole")]
        [Restrict(AllowVerbs = "GET")]
        [Produces("application/json")]        
        [ProducesResponseType(typeof(Result<IList<RoleEntity>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetRole()
        {
            try
            {
                var result = await _mediator.Send(new GetRoleQuery());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// API Endpoint for Displaying Role by modal.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with Role Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPost("GetRoleByModel")]
        [Restrict(AllowVerbs = "POST")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<IList<RoleEntity>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetRole(GetRoleModel? rqModel)
        {
            try
            {
                var result = await _mediator.Send(new GetRoleByModalQuery(rqModel));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// API Endpoint for Adding Role.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with Role Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPost("AddRole")]
        [Restrict(AllowVerbs = "POST")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<QueryResEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> AddRole(AddRoleModel rqModel)
        {
            try
            {
               
                if (rqModel != null)
                {
                    // Validate the model
                    var validator = new AddRoleValidator(); // Assuming you have a validator for AddRoleModel
                    var validationResult = await validator.ValidateAsync(rqModel);

                    // Check if validation failed
                    if (!validationResult.IsValid)
                    {
                        return BadRequest(validationResult.Errors);
                    }

                    // If the model is valid or null, proceed with the command
                    var result = await _mediator.Send(new AddRoleCommand(rqModel));
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Role Request Model is Invalid");
                }
                
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// API Endpoint for Update Role.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with Role Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPut("UpdateRole")]
        [Restrict(AllowVerbs = "PUT")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<QueryResEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateRole(UpdateRoleModel rqModel)
        {
            try
            {

                if (rqModel != null)
                {
                    // Validate the model
                    var validator = new UpdateRoleValidator(); // Assuming you have a validator for AddRoleModel
                    var validationResult = await validator.ValidateAsync(rqModel);

                    // Check if validation failed
                    if (!validationResult.IsValid)
                    {
                        return BadRequest(validationResult.Errors);
                    }

                    // If the model is valid or null, proceed with the command
                    var result = await _mediator.Send(new UpdateRoleCommand(rqModel));
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Role Request Model is Invalid");
                }

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// API Endpoint for Update Role Status.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with Role Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPatch("UpdateRoleStatus")]
        [Restrict(AllowVerbs = "PATCH")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<QueryResEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateRoleStatus(RequestRoleStatusModel rqModel)
        {
            try
            {

                if (rqModel != null)
                {

                    // If the model is valid or null, proceed with the command
                    var result = await _mediator.Send(new UpdateRoleStatusCommand(rqModel));
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Role Request Model is Invalid");
                }

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        #endregion Role

    }
}

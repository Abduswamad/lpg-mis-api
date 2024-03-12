using Gas.Application.Features.GenderFeatures.CommandHandler;
using Gas.Application.Features.GenderFeatures.QueryHandler;
using Gas.Application.Features.GenderFeatures.Validator;
using Gas.Common;
using Gas.Domain.Entities;
using Gas.Domain.Entity.PublicManagement;
using Gas.Model.PublicManagement;
using Gas.Utils;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Gas.WebAPI.Controllers.v1.GMS.Controllers
{
    /// <summary>
    /// API Endpoint Controller for Gender Management.
    /// </summary>
    [Route("api/v{version:apiversion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class GenderManagementController : ControllerBase
    {
        /// <summary>
        /// The mediator instance used for handling communication between components.
        /// </summary>
        private readonly IMediator _mediator;

        /// <summary>
        /// API Controller Instance for Gender Management.
        /// </summary>
        /// <param name="mediator">The mediator instance used for handling communication between components.</param>
        public GenderManagementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Gender

        /// <summary>
        /// API Endpoint for Displaying All Gender.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with Gender Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpGet("GetGender")]
        [Restrict(AllowVerbs = "GET")]
        [Produces("application/json")]        
        [ProducesResponseType(typeof(Result<IList<GenderEntity>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetGender()
        {
            try
            {
                var result = await _mediator.Send(new GetGenderQuery());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// API Endpoint for Displaying Gender by modal.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with Gender Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPost("GetGenderByModel")]
        [Restrict(AllowVerbs = "POST")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<IList<GenderEntity>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetGender(GetGenderModel? rqModel)
        {
            try
            {
                var result = await _mediator.Send(new GetGenderByModalQuery(rqModel));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// API Endpoint for Adding Gender.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with Gender Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPost("AddGender")]
        [Restrict(AllowVerbs = "POST")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<QueryResEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> AddGender(AddGenderModel rqModel)
        {
            try
            {
               
                if (rqModel != null)
                {
                    // Validate the model
                    var validator = new AddGenderValidator(); // Assuming you have a validator for AddGenderModel
                    var validationResult = await validator.ValidateAsync(rqModel);

                    // Check if validation failed
                    if (!validationResult.IsValid)
                    {
                        return BadRequest(validationResult.Errors);
                    }

                    // If the model is valid or null, proceed with the command
                    var result = await _mediator.Send(new AddGenderCommand(rqModel));
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Gender Request Model is Invalid");
                }
                
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// API Endpoint for Update Gender.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with Gender Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPut("UpdateGender")]
        [Restrict(AllowVerbs = "PUT")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<QueryResEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateGender(UpdateGenderModel rqModel)
        {
            try
            {

                if (rqModel != null)
                {
                    // Validate the model
                    var validator = new UpdateGenderValidator(); // Assuming you have a validator for AddGenderModel
                    var validationResult = await validator.ValidateAsync(rqModel);

                    // Check if validation failed
                    if (!validationResult.IsValid)
                    {
                        return BadRequest(validationResult.Errors);
                    }

                    // If the model is valid or null, proceed with the command
                    var result = await _mediator.Send(new UpdateGenderCommand(rqModel));
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Gender Request Model is Invalid");
                }

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// API Endpoint for Update Gender Status.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with Gender Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPatch("UpdateGenderStatus")]
        [Restrict(AllowVerbs = "PATCH")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<QueryResEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateGenderStatus(RequestGenderStatusModel rqModel)
        {
            try
            {

                if (rqModel != null)
                {

                    // If the model is valid or null, proceed with the command
                    var result = await _mediator.Send(new UpdateGenderStatusCommand(rqModel));
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Gender Request Model is Invalid");
                }

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        #endregion Gender

    }
}

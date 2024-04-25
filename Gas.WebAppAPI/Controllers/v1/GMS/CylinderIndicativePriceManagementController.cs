using Gas.Application.Features.CylinderIndicativePriceFeatures.CommandHandler;
using Gas.Application.Features.CylinderIndicativePriceFeatures.QueryHandler;
using Gas.Application.Features.CylinderIndicativePriceFeatures.Validator;
using Gas.Common;
using Gas.Domain.Entities;
using Gas.Domain.Entity.SalesManagement;
using Gas.Model.SalesManagement;
using Gas.Utils;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Gas.WebAPI.Controllers.v1.GMS.Controllers
{
    /// <summary>
    /// API Endpoint Controller for CylinderIndicativePrice Management.
    /// </summary>
    /// <remarks>
    /// API Controller Instance for CylinderIndicativePrice Management.
    /// </remarks>
    /// <param name="mediator">The mediator instance used for handling communication between components.</param>
    [Authorize()]
    [Route("api/v{version:apiversion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class CylinderIndicativePriceManagementController(IMediator mediator) : ControllerBase
    {
        /// <summary>
        /// The mediator instance used for handling communication between components.
        /// </summary>
        private readonly IMediator _mediator = mediator;

        #region CylinderIndicativePrice

        /// <summary>
        /// API Endpoint for Displaying All CylinderIndicativePrice.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with CylinderIndicativePrice Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpGet("GetCylinderIndicativePrice")]
        [Restrict(AllowVerbs = "GET")]
        [Produces("application/json")]        
        [ProducesResponseType(typeof(Result<IList<CylinderIndicativePriceEntity>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetCylinderIndicativePrice()
        {
            try
            {
                var result = await _mediator.Send(new GetCylinderIndicativePriceQuery());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// API Endpoint for Displaying CylinderIndicativePrice by modal.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with CylinderIndicativePrice Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPost("GetCylinderIndicativePriceByModel")]
        [Restrict(AllowVerbs = "POST")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<IList<CylinderIndicativePriceEntity>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetCylinderIndicativePrice(GetCylinderIndicativePriceModel? rqModel)
        {
            try
            {
                var result = await _mediator.Send(new GetCylinderIndicativePriceByModalQuery(rqModel));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// API Endpoint for Adding CylinderIndicativePrice.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with CylinderIndicativePrice Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPost("AddCylinderIndicativePrice")]
        [Restrict(AllowVerbs = "POST")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<QueryResEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> AddCylinderIndicativePrice(AddCylinderIndicativePriceModel rqModel)
        {
            try
            {
               
                if (rqModel != null)
                {
                    // Validate the model
                    var validator = new AddCylinderIndicativePriceValidator(); // Assuming you have a validator for AddCylinderIndicativePriceModel
                    var validationResult = await validator.ValidateAsync(rqModel);

                    // Check if validation failed
                    if (!validationResult.IsValid)
                    {
                        return BadRequest(validationResult.Errors);
                    }

                    // If the model is valid or null, proceed with the command
                    var result = await _mediator.Send(new AddCylinderIndicativePriceCommand(rqModel));
                    return Ok(result);
                }
                else
                {
                    return BadRequest("CylinderIndicativePrice Request Model is Invalid");
                }
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// API Endpoint for Update CylinderIndicativePrice.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with CylinderIndicativePrice Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPut("UpdateCylinderIndicativePrice")]
        [Restrict(AllowVerbs = "PUT")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<QueryResEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> UpdateCylinderIndicativePrice(UpdateCylinderIndicativePriceModel rqModel)
        {
            try
            {

                if (rqModel != null)
                {
                    // Validate the model
                    var validator = new UpdateCylinderIndicativePriceValidator(); // Assuming you have a validator for AddCylinderIndicativePriceModel
                    var validationResult = await validator.ValidateAsync(rqModel);

                    // Check if validation failed
                    if (!validationResult.IsValid)
                    {
                        return BadRequest(validationResult.Errors);
                    }

                    // If the model is valid or null, proceed with the command
                    var result = await _mediator.Send(new UpdateCylinderIndicativePriceCommand(rqModel));
                    return Ok(result);
                }
                else
                {
                    return BadRequest("CylinderIndicativePrice Request Model is Invalid");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// API Endpoint for Update CylinderIndicativePrice Status.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with CylinderIndicativePrice Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPatch("UpdateCylinderIndicativePriceStatus")]
        [Restrict(AllowVerbs = "PATCH")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<QueryResEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> UpdateCylinderIndicativePriceStatus(UpdateCylinderIndicativePriceStatusModel rqModel)
        {
            try
            {

                if (rqModel != null)
                {
                    // If the model is valid or null, proceed with the command
                    var result = await _mediator.Send(new UpdateCylinderIndicativePriceStatusCommand(rqModel));
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Cylinder Indicative Price Request Model is Invalid");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        #endregion CylinderIndicativePrice

    }
}

using Gas.Application.Features.AccessoryIndicativePriceFeatures.CommandHandler;
using Gas.Application.Features.AccessoryIndicativePriceFeatures.QueryHandler;
using Gas.Application.Features.AccessoryIndicativePriceFeatures.Validator;
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
    /// API Endpoint Controller for AccessoryIndicativePrice Management.
    /// </summary>
    [Authorize()]
    [Route("api/v{version:apiversion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AccessoryIndicativePriceManagementController : ControllerBase
    {
        /// <summary>
        /// The mediator instance used for handling communication between components.
        /// </summary>
        private readonly IMediator _mediator;

        /// <summary>
        /// API Controller Instance for AccessoryIndicativePrice Management.
        /// </summary>
        /// <param name="mediator">The mediator instance used for handling communication between components.</param>
        public AccessoryIndicativePriceManagementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region AccessoryIndicativePrice

        /// <summary>
        /// API Endpoint for Displaying All AccessoryIndicativePrice.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with AccessoryIndicativePrice Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpGet("GetAccessoryIndicativePrice")]
        [Restrict(AllowVerbs = "GET")]
        [Produces("application/json")]        
        [ProducesResponseType(typeof(Result<IList<AccessoryIndicativePriceEntity>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetAccessoryIndicativePrice()
        {
            try
            {
                var result = await _mediator.Send(new GetAccessoryIndicativePriceQuery());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// API Endpoint for Displaying AccessoryIndicativePrice by modal.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with AccessoryIndicativePrice Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPost("GetAccessoryIndicativePriceByModel")]
        [Restrict(AllowVerbs = "POST")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<IList<AccessoryIndicativePriceEntity>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetAccessoryIndicativePrice(GetAccessoryIndicativePriceModel? rqModel)
        {
            try
            {
                var result = await _mediator.Send(new GetAccessoryIndicativePriceByModalQuery(rqModel));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// API Endpoint for Adding AccessoryIndicativePrice.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with AccessoryIndicativePrice Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPost("AddAccessoryIndicativePrice")]
        [Restrict(AllowVerbs = "POST")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<QueryResEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> AddAccessoryIndicativePrice(AddAccessoryIndicativePriceModel rqModel)
        {
            try
            {
               
                if (rqModel != null)
                {
                    // Validate the model
                    var validator = new AddAccessoryIndicativePriceValidator(); // Assuming you have a validator for AddAccessoryIndicativePriceModel
                    var validationResult = await validator.ValidateAsync(rqModel);

                    // Check if validation failed
                    if (!validationResult.IsValid)
                    {
                        return BadRequest(validationResult.Errors);
                    }

                    // If the model is valid or null, proceed with the command
                    var result = await _mediator.Send(new AddAccessoryIndicativePriceCommand(rqModel));
                    return Ok(result);
                }
                else
                {
                    return BadRequest("AccessoryIndicativePrice Request Model is Invalid");
                }
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// API Endpoint for Update AccessoryIndicativePrice.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with AccessoryIndicativePrice Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPut("UpdateAccessoryIndicativePrice")]
        [Restrict(AllowVerbs = "PUT")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<QueryResEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> UpdateAccessoryIndicativePrice(UpdateAccessoryIndicativePriceModel rqModel)
        {
            try
            {

                if (rqModel != null)
                {
                    // Validate the model
                    var validator = new UpdateAccessoryIndicativePriceValidator(); // Assuming you have a validator for AddAccessoryIndicativePriceModel
                    var validationResult = await validator.ValidateAsync(rqModel);

                    // Check if validation failed
                    if (!validationResult.IsValid)
                    {
                        return BadRequest(validationResult.Errors);
                    }

                    // If the model is valid or null, proceed with the command
                    var result = await _mediator.Send(new UpdateAccessoryIndicativePriceCommand(rqModel));
                    return Ok(result);
                }
                else
                {
                    return BadRequest("AccessoryIndicativePrice Request Model is Invalid");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// API Endpoint for Update AccessoryIndicativePrice Status.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with AccessoryIndicativePrice Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPatch("UpdateAccessoryIndicativePriceStatus")]
        [Restrict(AllowVerbs = "PATCH")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<QueryResEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> UpdateAccessoryIndicativePriceStatus(UpdateAccessoryIndicativePriceStatusModel rqModel)
        {
            try
            {

                if (rqModel != null)
                {
                    // If the model is valid or null, proceed with the command
                    var result = await _mediator.Send(new UpdateAccessoryIndicativePriceStatusCommand(rqModel));
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Accessory Indicative Price Request Model is Invalid");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        #endregion AccessoryIndicativePrice

    }
}

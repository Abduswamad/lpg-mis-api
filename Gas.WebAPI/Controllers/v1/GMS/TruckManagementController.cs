using Gas.Application.Features.TruckFeatures.CommandHandler;
using Gas.Application.Features.TruckFeatures.QueryHandler;
using Gas.Application.Features.TruckFeatures.Validator;
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
    /// API Endpoint Controller for Truck Management.
    /// </summary>
    [Route("api/v{version:apiversion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class TruckManagementController : ControllerBase
    {
        /// <summary>
        /// The mediator instance used for handling communication between components.
        /// </summary>
        private readonly IMediator _mediator;

        /// <summary>
        /// API Controller Instance for Truck Management.
        /// </summary>
        /// <param name="mediator">The mediator instance used for handling communication between components.</param>
        public TruckManagementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Truck

        /// <summary>
        /// API Endpoint for Displaying All Truck.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with Truck Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpGet("GetTruck")]
        [Restrict(AllowVerbs = "GET")]
        [Produces("application/json")]        
        [ProducesResponseType(typeof(Result<IList<TruckEntity>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetTruck()
        {
            try
            {
                var result = await _mediator.Send(new GetTruckQuery());
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// API Endpoint for Displaying Truck by modal.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with Truck Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPost("GetTruckByModel")]
        [Restrict(AllowVerbs = "POST")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<IList<TruckEntity>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetTruck(GetTruckModel? rqModel)
        {
            try
            {
                var result = await _mediator.Send(new GetTruckByModalQuery(rqModel));
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// API Endpoint for Adding Truck.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with Truck Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPost("AddTruck")]
        [Restrict(AllowVerbs = "POST")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<QueryResEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> AddTruck(AddTruckModel rqModel)
        {
            try
            {
               
                if (rqModel != null)
                {
                    // Validate the model
                    var validator = new AddTruckValidator(); // Assuming you have a validator for AddTruckModel
                    var validationResult = await validator.ValidateAsync(rqModel);

                    // Check if validation failed
                    if (!validationResult.IsValid)
                    {
                        return BadRequest(validationResult.Errors);
                    }

                    // If the model is valid or null, proceed with the command
                    var result = await _mediator.Send(new AddTruckCommand(rqModel));
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Truck Request Model is Invalid");
                }
                
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// API Endpoint for Update Truck.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with Truck Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPut("UpdateTruck")]
        [Restrict(AllowVerbs = "PUT")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<QueryResEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateTruck(UpdateTruckModel rqModel)
        {
            try
            {

                if (rqModel != null)
                {
                    // Validate the model
                    var validator = new UpdateTruckValidator(); // Assuming you have a validator for AddTruckModel
                    var validationResult = await validator.ValidateAsync(rqModel);

                    // Check if validation failed
                    if (!validationResult.IsValid)
                    {
                        return BadRequest(validationResult.Errors);
                    }

                    // If the model is valid or null, proceed with the command
                    var result = await _mediator.Send(new UpdateTruckCommand(rqModel));
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Truck Request Model is Invalid");
                }

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// API Endpoint for Update Truck Status.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with Truck Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPatch("UpdateTruckStatus")]
        [Restrict(AllowVerbs = "PATCH")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<QueryResEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateTruckStatus(RequestTruckStatusModel rqModel)
        {
            try
            {

                if (rqModel != null)
                {

                    // If the model is valid or null, proceed with the command
                    var result = await _mediator.Send(new UpdateTruckStatusCommand(rqModel));
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Truck Request Model is Invalid");
                }

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        #endregion Truck

    }
}

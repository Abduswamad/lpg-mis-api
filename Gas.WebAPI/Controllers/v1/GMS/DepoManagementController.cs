using Gas.Application.Features.DepoFeatures.CommandHandler;
using Gas.Application.Features.DepoFeatures.QueryHandler;
using Gas.Application.Features.DepoFeatures.Validator;
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
    /// API Endpoint Controller for Depo Management.
    /// </summary>
    [Route("api/v{version:apiversion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class DepoManagementController : ControllerBase
    {
        /// <summary>
        /// The mediator instance used for handling communication between components.
        /// </summary>
        private readonly IMediator _mediator;

        /// <summary>
        /// API Controller Instance for Depo Management.
        /// </summary>
        /// <param name="mediator">The mediator instance used for handling communication between components.</param>
        public DepoManagementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Depo

        /// <summary>
        /// API Endpoint for Displaying All Depo.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with Depo Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpGet("GetDepo")]
        [Restrict(AllowVerbs = "GET")]
        [Produces("application/json")]        
        [ProducesResponseType(typeof(Result<IList<DepoEntity>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetDepo()
        {
            try
            {
                var result = await _mediator.Send(new GetDepoQuery());
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// API Endpoint for Displaying Depo by modal.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with Depo Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPost("GetDepoByModel")]
        [Restrict(AllowVerbs = "POST")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<IList<DepoEntity>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetDepo(GetDepoModel? rqModel)
        {
            try
            {
                var result = await _mediator.Send(new GetDepoByModalQuery(rqModel));
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// API Endpoint for Adding Depo.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with Depo Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPost("AddDepo")]
        [Restrict(AllowVerbs = "POST")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<QueryResEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> AddDepo(AddDepoModel rqModel)
        {
            try
            {
               
                if (rqModel != null)
                {
                    // Validate the model
                    var validator = new AddDepoValidator(); // Assuming you have a validator for AddDepoModel
                    var validationResult = await validator.ValidateAsync(rqModel);

                    // Check if validation failed
                    if (!validationResult.IsValid)
                    {
                        return BadRequest(validationResult.Errors);
                    }

                    // If the model is valid or null, proceed with the command
                    var result = await _mediator.Send(new AddDepoCommand(rqModel));
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Depo Request Model is Invalid");
                }
                
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// API Endpoint for Update Depo.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with Depo Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPut("UpdateDepo")]
        [Restrict(AllowVerbs = "PUT")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<QueryResEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateDepo(UpdateDepoModel rqModel)
        {
            try
            {

                if (rqModel != null)
                {
                    // Validate the model
                    var validator = new UpdateDepoValidator(); // Assuming you have a validator for AddDepoModel
                    var validationResult = await validator.ValidateAsync(rqModel);

                    // Check if validation failed
                    if (!validationResult.IsValid)
                    {
                        return BadRequest(validationResult.Errors);
                    }

                    // If the model is valid or null, proceed with the command
                    var result = await _mediator.Send(new UpdateDepoCommand(rqModel));
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Depo Request Model is Invalid");
                }

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// API Endpoint for Update Depo Status.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with Depo Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPatch("UpdateDepoStatus")]
        [Restrict(AllowVerbs = "PATCH")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<QueryResEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateDepoStatus(RequestDepoStatusModel rqModel)
        {
            try
            {

                if (rqModel != null)
                {

                    // If the model is valid or null, proceed with the command
                    var result = await _mediator.Send(new UpdateDepoStatusCommand(rqModel));
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Depo Request Model is Invalid");
                }

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        #endregion Depo

    }
}

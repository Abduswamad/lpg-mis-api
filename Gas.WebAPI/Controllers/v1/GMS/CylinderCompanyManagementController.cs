using Gas.Application.Features.CylindercompanyFeatures.CommandHandler;
using Gas.Application.Features.CylindercompanyFeatures.QueryHandler;
using Gas.Application.Features.CylindercompanyFeatures.Validator;
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
    /// API Endpoint Controller for Cylindercompany Management.
    /// </summary>
    [Route("api/v{version:apiversion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class CylindercompanyManagementController : ControllerBase
    {
        /// <summary>
        /// The mediator instance used for handling communication between components.
        /// </summary>
        private readonly IMediator _mediator;

        /// <summary>
        /// API Controller Instance for Cylindercompany Management.
        /// </summary>
        /// <param name="mediator">The mediator instance used for handling communication between components.</param>
        public CylindercompanyManagementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Cylindercompany

        /// <summary>
        /// API Endpoint for Displaying All Cylindercompany.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with Cylindercompany Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpGet("GetCylindercompany")]
        [Restrict(AllowVerbs = "GET")]
        [Produces("application/json")]        
        [ProducesResponseType(typeof(Result<IList<CylindercompanyEntity>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetCylindercompany()
        {
            try
            {
                var result = await _mediator.Send(new GetCylindercompanyQuery());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// API Endpoint for Displaying Cylindercompany by modal.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with Cylindercompany Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPost("GetCylindercompanyByModel")]
        [Restrict(AllowVerbs = "POST")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<IList<CylindercompanyEntity>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetCylindercompany(GetCylindercompanyModel? rqModel)
        {
            try
            {
                var result = await _mediator.Send(new GetCylindercompanyByModalQuery(rqModel));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// API Endpoint for Adding Cylindercompany.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with Cylindercompany Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPost("AddCylindercompany")]
        [Restrict(AllowVerbs = "POST")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<QueryResEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> AddCylindercompany(AddCylindercompanyModel rqModel)
        {
            try
            {
               
                if (rqModel != null)
                {
                    // Validate the model
                    var validator = new AddCylindercompanyValidator(); // Assuming you have a validator for AddCylindercompanyModel
                    var validationResult = await validator.ValidateAsync(rqModel);

                    // Check if validation failed
                    if (!validationResult.IsValid)
                    {
                        return BadRequest(validationResult.Errors);
                    }

                    // If the model is valid or null, proceed with the command
                    var result = await _mediator.Send(new AddCylindercompanyCommand(rqModel));
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Cylindercompany Request Model is Invalid");
                }
                
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// API Endpoint for Update Cylindercompany.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with Cylindercompany Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPut("UpdateCylindercompany")]
        [Restrict(AllowVerbs = "PUT")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<QueryResEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateCylindercompany(UpdateCylindercompanyModel rqModel)
        {
            try
            {

                if (rqModel != null)
                {
                    // Validate the model
                    var validator = new UpdateCylindercompanyValidator(); // Assuming you have a validator for AddCylindercompanyModel
                    var validationResult = await validator.ValidateAsync(rqModel);

                    // Check if validation failed
                    if (!validationResult.IsValid)
                    {
                        return BadRequest(validationResult.Errors);
                    }

                    // If the model is valid or null, proceed with the command
                    var result = await _mediator.Send(new UpdateCylindercompanyCommand(rqModel));
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Cylindercompany Request Model is Invalid");
                }

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// API Endpoint for Update Cylindercompany Status.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with Cylindercompany Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPatch("UpdateCylindercompanyStatus")]
        [Restrict(AllowVerbs = "PATCH")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<QueryResEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateCylindercompanyStatus(RequestCylindercompanyStatusModel rqModel)
        {
            try
            {

                if (rqModel != null)
                {

                    // If the model is valid or null, proceed with the command
                    var result = await _mediator.Send(new UpdateCylindercompanyStatusCommand(rqModel));
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Cylindercompany Request Model is Invalid");
                }

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        #endregion Cylindercompany

    }
}

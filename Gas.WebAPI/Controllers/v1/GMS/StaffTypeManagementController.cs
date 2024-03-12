using Gas.Application.Features.StafftypeFeatures.CommandHandler;
using Gas.Application.Features.StafftypeFeatures.QueryHandler;
using Gas.Application.Features.StafftypeFeatures.Validator;
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
    /// API Endpoint Controller for Stafftype Management.
    /// </summary>
    [Route("api/v{version:apiversion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class StafftypeManagementController : ControllerBase
    {
        /// <summary>
        /// The mediator instance used for handling communication between components.
        /// </summary>
        private readonly IMediator _mediator;

        /// <summary>
        /// API Controller Instance for Stafftype Management.
        /// </summary>
        /// <param name="mediator">The mediator instance used for handling communication between components.</param>
        public StafftypeManagementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Stafftype

        /// <summary>
        /// API Endpoint for Displaying All Stafftype.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with Stafftype Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpGet("GetStafftype")]
        [Restrict(AllowVerbs = "GET")]
        [Produces("application/json")]        
        [ProducesResponseType(typeof(Result<IList<StaffTypeEntity>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetStafftype()
        {
            try
            {
                var result = await _mediator.Send(new GetStafftypeQuery());
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// API Endpoint for Displaying Stafftype by modal.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with Stafftype Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPost("GetStafftypeByModel")]
        [Restrict(AllowVerbs = "POST")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<IList<StaffTypeEntity>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetStafftype(GetStafftypeModel? rqModel)
        {
            try
            {
                var result = await _mediator.Send(new GetStafftypeByModalQuery(rqModel));
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// API Endpoint for Adding Stafftype.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with Stafftype Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPost("AddStafftype")]
        [Restrict(AllowVerbs = "POST")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<QueryResEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> AddStafftype(AddStafftypeModel rqModel)
        {
            try
            {
               
                if (rqModel != null)
                {
                    // Validate the model
                    var validator = new AddStafftypeValidator(); // Assuming you have a validator for AddStafftypeModel
                    var validationResult = await validator.ValidateAsync(rqModel);

                    // Check if validation failed
                    if (!validationResult.IsValid)
                    {
                        return BadRequest(validationResult.Errors);
                    }

                    // If the model is valid or null, proceed with the command
                    var result = await _mediator.Send(new AddStafftypeCommand(rqModel));
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Stafftype Request Model is Invalid");
                }
                
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// API Endpoint for Update Stafftype.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with Stafftype Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPut("UpdateStafftype")]
        [Restrict(AllowVerbs = "PUT")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<QueryResEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateStafftype(UpdateStafftypeModel rqModel)
        {
            try
            {

                if (rqModel != null)
                {
                    // Validate the model
                    var validator = new UpdateStafftypeValidator(); // Assuming you have a validator for AddStafftypeModel
                    var validationResult = await validator.ValidateAsync(rqModel);

                    // Check if validation failed
                    if (!validationResult.IsValid)
                    {
                        return BadRequest(validationResult.Errors);
                    }

                    // If the model is valid or null, proceed with the command
                    var result = await _mediator.Send(new UpdateStafftypeCommand(rqModel));
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Stafftype Request Model is Invalid");
                }

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// API Endpoint for Update Stafftype Status.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with Stafftype Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPatch("UpdateStafftypeStatus")]
        [Restrict(AllowVerbs = "PATCH")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<QueryResEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateStafftypeStatus(RequestStafftypeStatusModel rqModel)
        {
            try
            {

                if (rqModel != null)
                {

                    // If the model is valid or null, proceed with the command
                    var result = await _mediator.Send(new UpdateStafftypeStatusCommand(rqModel));
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Stafftype Request Model is Invalid");
                }

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        #endregion Stafftype

    }
}

using Gas.Application.Features.ShopFeatures.CommandHandler;
using Gas.Application.Features.ShopFeatures.QueryHandler;
using Gas.Application.Features.ShopFeatures.Validator;
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
    /// API Endpoint Controller for Shop Management.
    /// </summary>
    /// <remarks>
    /// API Controller Instance for Shop Management.
    /// </remarks>
    /// <param name="mediator">The mediator instance used for handling communication between components.</param>
    [Authorize()]
    [Route("api/v{version:apiversion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ShopManagementController(IMediator mediator) : ControllerBase
    {
        /// <summary>
        /// The mediator instance used for handling communication between components.
        /// </summary>
        private readonly IMediator _mediator = mediator;

        #region Shop

        /// <summary>
        /// API Endpoint for Displaying All Shop.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with Shop Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpGet("GetShop")]
        [Restrict(AllowVerbs = "GET")]
        [Produces("application/json")]        
        [ProducesResponseType(typeof(Result<IList<ShopEntity>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetShop()
        {
            try
            {
                var result = await _mediator.Send(new GetShopQuery());
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
        /// API Endpoint for Displaying Shop by modal.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with Shop Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPost("GetShopByModel")]
        [Restrict(AllowVerbs = "POST")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<IList<ShopEntity>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetShop(GetShopModel? rqModel)
        {
            try
            {
                var result = await _mediator.Send(new GetShopByModalQuery(rqModel));
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
        /// API Endpoint for Adding Shop.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with Shop Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPost("AddShop")]
        [Restrict(AllowVerbs = "POST")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<QueryResEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> AddShop(AddShopModel rqModel)
        {
            try
            {               
                if (rqModel != null)
                {
                    // Validate the model
                    var validator = new AddShopValidator(); // Assuming you have a validator for AddShopModel
                    var validationResult = await validator.ValidateAsync(rqModel);

                    // Check if validation failed
                    if (!validationResult.IsValid)
                    {
                        return BadRequest(validationResult.Errors);
                    }

                    // If the model is valid or null, proceed with the command
                    var result = await _mediator.Send(new AddShopCommand(rqModel));
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Shop Request Model is Invalid");
                }
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// API Endpoint for Update Shop.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with Shop Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPut("UpdateShop")]
        [Restrict(AllowVerbs = "PUT")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<QueryResEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> UpdateShop(UpdateShopModel rqModel)
        {
            try
            {
                if (rqModel != null)
                {
                    // Validate the model
                    var validator = new UpdateShopValidator(); // Assuming you have a validator for AddShopModel
                    var validationResult = await validator.ValidateAsync(rqModel);

                    // Check if validation failed
                    if (!validationResult.IsValid)
                    {
                        return BadRequest(validationResult.Errors);
                    }

                    // If the model is valid or null, proceed with the command
                    var result = await _mediator.Send(new UpdateShopCommand(rqModel));
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Shop Request Model is Invalid");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// API Endpoint for Update Shop Status.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with Shop Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPatch("UpdateShopStatus")]
        [Restrict(AllowVerbs = "PATCH")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<QueryResEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> UpdateShopStatus(RequestShopStatusModel rqModel)
        {
            try
            {
                if (rqModel != null)
                {
                    // If the model is valid or null, proceed with the command
                    var result = await _mediator.Send(new UpdateShopStatusCommand(rqModel));
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Shop Request Model is Invalid");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion Shop

    }
}

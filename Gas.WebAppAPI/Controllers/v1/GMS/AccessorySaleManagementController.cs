﻿using Gas.Application.Features.AccessorySaleFeatures.CommandHandler;
using Gas.Application.Features.AccessorySaleFeatures.QueryHandler;
using Gas.Application.Features.AccessorySaleFeatures.Validator;
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
    /// API Endpoint Controller for AccessorySale Management.
    /// </summary>
    /// <remarks>
    /// API Controller Instance for AccessorySale Management.
    /// </remarks>
    /// <param name="mediator">The mediator instance used for handling communication between components.</param>
    [Authorize()]
    [Route("api/v{version:apiversion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AccessorySaleManagementController(IMediator mediator) : ControllerBase
    {
        /// <summary>
        /// The mediator instance used for handling communication between components.
        /// </summary>
        private readonly IMediator _mediator = mediator;

        #region AccessorySale

        /// <summary>
        /// API Endpoint for Displaying All AccessorySale.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with AccessorySale Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpGet("GetAccessorySale")]
        [Restrict(AllowVerbs = "GET")]
        [Produces("application/json")]        
        [ProducesResponseType(typeof(Result<IList<AccessorySaleEntity>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetAccessorySale()
        {
            try
            {
                var result = await _mediator.Send(new GetAccessorySaleQuery());
                var superDealerId = User.GetSuperDealerId();
                if (result.Data.Count > 0)
                {
                    result.Data = [.. result.Data.Where(x => x.Super_dealer_id == superDealerId).OrderByDescending(x => x.Accessory_sale_id)];
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// API Endpoint for Displaying AccessorySale by modal.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with AccessorySale Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPost("GetAccessorySaleByModel")]
        [Restrict(AllowVerbs = "POST")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<IList<AccessorySaleEntity>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetAccessorySaleByModel(GetAccessorySaleModel? rqModel)
        {
            try
            {
                var result = await _mediator.Send(new GetAccessorySaleByModalQuery(rqModel));
                var superDealerId = User.GetSuperDealerId();
                if (result.Data.Count > 0)
                {
                    result.Data = [.. result.Data.Where(x => x.Super_dealer_id == superDealerId).OrderByDescending(x => x.Accessory_sale_id)];
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// API Endpoint for Displaying AccessorySale item by id.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with AccessorySale Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpGet("GetAccessorySalesItemById")]
        [Restrict(AllowVerbs = "GET")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<IList<AccessorySalesItemEntity>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetAccessorySalesItemById(int AccessorySalesId)
        {
            try
            {
                GetAccessorySalesItemModel? rqModel = new()
                {
                    AccessorySaleId = AccessorySalesId
                };
                var result = await _mediator.Send(new GetAccessorySalesItemByModalQuery(rqModel));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// API Endpoint for Displaying AccessorySale by modal.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with AccessorySale Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPost("GetAccessorySalesItemByModel")]
        [Restrict(AllowVerbs = "POST")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<IList<AccessorySalesItemEntity>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetAccessorySalesItemByModel(GetAccessorySalesItemModel? rqModel)
        {
            try
            {
                var result = await _mediator.Send(new GetAccessorySalesItemByModalQuery(rqModel));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// API Endpoint for Adding AccessorySale.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with AccessorySale Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPost("AddAccessorySale")]
        [Restrict(AllowVerbs = "POST")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<QueryResEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> AddAccessorySale(AddAccessorySaleModel? rqModel)
        {
            try
            {
               
                if (rqModel != null)
                {
                    // Validate the model
                    var validator = new AddAccessorySaleValidator(); // Assuming you have a validator for AddAccessorySaleModel
                    var validationResult = await validator.ValidateAsync(rqModel);

                    // Check if validation failed
                    if (!validationResult.IsValid)
                    {
                        return BadRequest(validationResult.Errors);
                    }

                    // If the model is valid or null, proceed with the command
                    var result = await _mediator.Send(new AddAccessorySaleCommand(rqModel));
                    return Ok(result);
                }
                else
                {
                    return BadRequest("AccessorySale Request Model is Invalid");
                }
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// API Endpoint for Adding Accessory Sale with Items.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with AccessorySale Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPost("AddAccessorySalesWithItem")]
        [Restrict(AllowVerbs = "POST")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<QueryResEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> AddAccessorySalesWithItem(AddAccessorySaleWithItemModel? rqModel)
        {
            try
            {

                if (rqModel != null)
                {
                    // Validate the model
                    var validator = new AddAccessorySalesItemListModelValidator(); // Assuming you have a validator for AddAccessorySaleModel
                    var validationResult = await validator.ValidateAsync(rqModel);

                    // Check if validation failed
                    if (!validationResult.IsValid)
                    {
                        return BadRequest(validationResult.Errors);
                    }

                    // If the model is valid or null, proceed with the command
                    var result = await _mediator.Send(new AddAccessorySalesWithItemCommand(rqModel));
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Accessory Sale Item Request Model is Invalid");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// API Endpoint for Delete Accessory Sale.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with AccessorySale Delete Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpDelete("DeleteAccessorySale")]
        [Restrict(AllowVerbs = "DELETE")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<QueryResEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> DeleteAccessorySale(DeleteAccessorySaleModel rqModel)
        {
            try
            {

                if (rqModel != null)
                {
                    // Validate the model
                    var validator = new DeleteAccessorySaleValidator(); // Assuming you have a validator for AddAccessorySaleModel
                    var validationResult = await validator.ValidateAsync(rqModel);

                    // Check if validation failed
                    if (!validationResult.IsValid)
                    {
                        return BadRequest(validationResult.Errors);
                    }

                    // If the model is valid or null, proceed with the command
                    var result = await _mediator.Send(new DeleteAccessorySaleCommand(rqModel));
                    return Ok(result);
                }
                else
                {
                    return BadRequest("AccessorySale Request Model is Invalid");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// API Endpoint for Delete Accessory Sales Item.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with AccessorySale Delete Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpDelete("DeleteAccessorySalesItem")]
        [Restrict(AllowVerbs = "DELETE")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<QueryResEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> DeleteAccessorySalesItem(DeleteAccessorySalesItemModel rqModel)
        {
            try
            {

                if (rqModel != null)
                {
                    // Validate the model
                    var validator = new DeleteAccessorySalesItemValidator(); // Assuming you have a validator for AddAccessorySaleModel
                    var validationResult = await validator.ValidateAsync(rqModel);

                    // Check if validation failed
                    if (!validationResult.IsValid)
                    {
                        return BadRequest(validationResult.Errors);
                    }

                    // If the model is valid or null, proceed with the command
                    var result = await _mediator.Send(new DeleteAccessorySalesItemCommand(rqModel));
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Accessory Sale Item Request Model is Invalid");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// API Endpoint for Displaying Accessory Total Sale.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with Accessory Total Sale Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPost("GetAccessoryTotalSales")]
        [Restrict(AllowVerbs = "POST")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<IList<AccessoryTotalSaleEntity>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetAccessoryTotalSales(SalesTotalModel? rqModel)
        {
            try
            {
                var result = await _mediator.Send(new GetAccessoryTotalSaleQuery(rqModel));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        #endregion AccessorySale

    }
}

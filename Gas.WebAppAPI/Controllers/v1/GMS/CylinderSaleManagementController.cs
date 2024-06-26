﻿using Gas.Application.Features.CylinderSaleFeatures.CommandHandler;
using Gas.Application.Features.CylinderSaleFeatures.QueryHandler;
using Gas.Application.Features.CylinderSaleFeatures.Validator;
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
    /// API Endpoint Controller for CylinderSale Management.
    /// </summary>
    /// <remarks>
    /// API Controller Instance for CylinderSale Management.
    /// </remarks> 
    /// <param name="mediator">The mediator instance used for handling communication between components.</param>
    [Authorize()]
    [Route("api/v{version:apiversion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class CylinderSaleManagementController(IMediator mediator) : ControllerBase
    {
        /// <summary>
        /// The mediator instance used for handling communication between components.
        /// </summary>
        private readonly IMediator _mediator = mediator;

        #region CylinderSale

        /// <summary>
        /// API Endpoint for Displaying All CylinderSale.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with CylinderSale Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpGet("GetCylinderSale")]
        [Restrict(AllowVerbs = "GET")]
        [Produces("application/json")]        
        [ProducesResponseType(typeof(Result<IList<CylinderSaleEntity>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetCylinderSale()
        {
            try
            {
                var result = await _mediator.Send(new GetCylinderSaleQuery());
                var superDealerId = User.GetSuperDealerId();
                if (result.Data.Count > 0)
                {
                    result.Data = [.. result.Data.Where(x => x.Super_dealer_id == superDealerId).OrderByDescending(x => x.Cylinder_sale_id)];
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// API Endpoint for Displaying CylinderSale by modal.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with CylinderSale Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPost("GetCylinderSaleByModel")]
        [Restrict(AllowVerbs = "POST")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<IList<CylinderSaleEntity>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetCylinderSale(GetCylinderSaleModel? rqModel)
        {
            try
            {
                var result = await _mediator.Send(new GetCylinderSaleByModalQuery(rqModel));
                var superDealerId = User.GetSuperDealerId();
                if (result.Data.Count > 0)
                {
                    result.Data = [.. result.Data.Where(x => x.Super_dealer_id == superDealerId).OrderByDescending(x => x.Cylinder_sale_id)];
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// API Endpoint for Displaying CylinderSale item by id.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with CylinderSale Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpGet("GetCylinderSalesItemById")]
        [Restrict(AllowVerbs = "GET")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<IList<CylinderSalesItemEntity>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetCylinderSalesItemById(int CylinderSalesId)
        {
            try
            {
                GetCylinderSalesItemModel? rqModel = new()
                {
                    Cylindersaleid = CylinderSalesId
                };
                var result = await _mediator.Send(new GetCylinderSalesItemByModalQuery(rqModel));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// API Endpoint for Displaying CylinderSale by modal.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with CylinderSale Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPost("GetCylinderSalesItemByModel")]
        [Restrict(AllowVerbs = "POST")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<IList<CylinderSalesItemEntity>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetCylinderSalesItemByModel(GetCylinderSalesItemModel? rqModel)
        {
            try
            {
                var result = await _mediator.Send(new GetCylinderSalesItemByModalQuery(rqModel));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// API Endpoint for Adding CylinderSale.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with CylinderSale Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPost("AddCylinderSale")]
        [Restrict(AllowVerbs = "POST")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<QueryResEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> AddCylinderSale(AddCylinderSaleModel? rqModel)
        {
            try
            {
               
                if (rqModel != null)
                {
                    // Validate the model
                    var validator = new AddCylinderSaleValidator(); // Assuming you have a validator for AddCylinderSaleModel
                    var validationResult = await validator.ValidateAsync(rqModel);

                    // Check if validation failed
                    if (!validationResult.IsValid)
                    {
                        return BadRequest(validationResult.Errors);
                    }

                    // If the model is valid or null, proceed with the command
                    var result = await _mediator.Send(new AddCylinderSaleCommand(rqModel));
                    return Ok(result);
                }
                else
                {
                    return BadRequest("CylinderSale Request Model is Invalid");
                }
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// API Endpoint for Adding Cylinder Sale with Items.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with CylinderSale Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPost("AddCylinderSalesWithItem")]
        [Restrict(AllowVerbs = "POST")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<QueryResEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> AddCylinderSalesWithItem(AddCylinderSalesWithItemModel? rqModel)
        {
            try
            {

                if (rqModel != null)
                {
                    // Validate the model
                    var validator = new AddCylinderSalesItemListModelValidator(); // Assuming you have a validator for AddCylinderSaleModel
                    var validationResult = await validator.ValidateAsync(rqModel);

                    // Check if validation failed
                    if (!validationResult.IsValid)
                    {
                        return BadRequest(validationResult.Errors);
                    }

                    // If the model is valid or null, proceed with the command
                    var result = await _mediator.Send(new AddCylinderSalesWithItemCommand(rqModel));
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Cylinder Sale Item Request Model is Invalid");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// API Endpoint for Delete Cylinder Sales Item.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with CylinderSale Delete Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpDelete("DeleteCylinderSale")]
        [Restrict(AllowVerbs = "DELETE")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<QueryResEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> DeleteCylinderSale(DeleteCylinderSaleModel rqModel)
        {
            try
            {

                if (rqModel != null)
                {
                    // Validate the model
                    var validator = new DeleteCylinderSaleValidator(); // Assuming you have a validator for AddCylinderSaleModel
                    var validationResult = await validator.ValidateAsync(rqModel);

                    // Check if validation failed
                    if (!validationResult.IsValid)
                    {
                        return BadRequest(validationResult.Errors);
                    }

                    // If the model is valid or null, proceed with the command
                    var result = await _mediator.Send(new DeleteCylinderSaleCommand(rqModel));
                    return Ok(result);
                }
                else
                {
                    return BadRequest("CylinderSale Request Model is Invalid");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// API Endpoint for Delete Cylinder Sales Item.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with CylinderSale Delete Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpDelete("DeleteCylinderSalesItem")]
        [Restrict(AllowVerbs = "DELETE")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<QueryResEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> DeleteCylinderSalesItem(DeleteCylinderSalesItemModel rqModel)
        {
            try
            {

                if (rqModel != null)
                {
                    // Validate the model
                    var validator = new DeleteCylinderSalesItemValidator(); // Assuming you have a validator for AddCylinderSaleModel
                    var validationResult = await validator.ValidateAsync(rqModel);

                    // Check if validation failed
                    if (!validationResult.IsValid)
                    {
                        return BadRequest(validationResult.Errors);
                    }

                    // If the model is valid or null, proceed with the command
                    var result = await _mediator.Send(new DeleteCylinderSalesItemCommand(rqModel));
                    return Ok(result);
                }
                else
                {
                    return BadRequest("CylinderSale Request Model is Invalid");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// API Endpoint for Displaying Cylinder Total Sale.
        /// </summary>
        /// <param></param>
        /// <returns>The response model with Cylinder Total Sale Data.</returns>
        /// <response code="200">Successfully.</response>
        /// <response code="400">Invalid request data.</response>
        [HttpPost("GetCylinderTotalSales")]
        [Restrict(AllowVerbs = "POST")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Result<IList<CylinderTotalSaleEntity>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetCylinderTotalSales(SalesTotalModel? rqModel)
        {
            try
            {
                var result = await _mediator.Send(new GetCylinderTotalSaleQuery(rqModel));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        #endregion CylinderSale

    }
}

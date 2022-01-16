﻿using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Responses;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Controllers;

[ApiController]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogProductController : ControllerBase
{
    private readonly ILogger<CatalogProductController> _logger;
    private readonly ICatalogProductService _catalogProductService;

    public CatalogProductController(
        ILogger<CatalogProductController> logger,
        ICatalogProductService catalogProductService)
    {
        _logger = logger;
        _catalogProductService = catalogProductService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateProductResponse<int>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult> Add(CreateProductRequest request)
    {
        var result = await _catalogProductService.AddAsync(request.Name, request.Price, request.AvailableStock, request.CatalogBrandId, request.CatalogTypeId, request.Description, request.PictureFileName);

        if (result != null)
        {
            return Ok(new CreateProductResponse<int?>() { Id = result });
        }
        else
        {
            return BadRequest();
        }
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var result = await _catalogProductService.DeleteAsync(id);

        if (result != null)
        {
            return NoContent();
        }
        else
        {
            return BadRequest();
        }
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult> Update(UpdateProductRequest request)
    {
        var result = await _catalogProductService.UpdateAsync(request.Id, request.Name, request.Price, request.AvailableStock, request.CatalogBrandId, request.CatalogTypeId, request.Description, request.PictureFileName);

        if (result != null)
        {
            return NoContent();
        }
        else
        {
            return BadRequest();
        }
    }
}

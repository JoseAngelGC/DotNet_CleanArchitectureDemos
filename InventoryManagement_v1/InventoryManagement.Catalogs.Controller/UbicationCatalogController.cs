﻿using InventoryManagement.Adstractions.UseCasesPorts.commons;
using InventoryManagement.Adstractions.UseCasesPorts;
using InventoryManagement.Dtos.Abstractions;
using InventoryManagement.Entities.Catalogs;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using InventoryManagement.Dtos.Catalogs;

namespace InventoryManagement.Catalogs.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Description("[ProductTypeCatalog EndPoints]")]
    public class UbicationCatalogController : ControllerBase
    {
        private readonly ICatalogUseCaseInputPort<UbicationCatalog> _catalogUseCaseInputPort;
        private readonly IResponseOutputPort<IResponseResult> _responseOutputPort;
        public UbicationCatalogController(ICatalogUseCaseInputPort<UbicationCatalog> catalogUseCaseInputPort, IResponseOutputPort<IResponseResult> responseOutputPort)
        {
            _catalogUseCaseInputPort = catalogUseCaseInputPort;
            _responseOutputPort = responseOutputPort;
        }

        [HttpGet("items")]
        public async Task<ActionResult<IResponseResult>> GetCurrencyItemsAsync()
        {
            await _catalogUseCaseInputPort.ShowAllRecordsAsync();
            return Ok(_responseOutputPort.Content);
        }

        [HttpPost("item/{id:int}")]
        public async Task<ActionResult<IResponseResult>> GetCurrencyItemAsync(int id, [FromBody] RequestCatalogDto request)
        {
            await _catalogUseCaseInputPort.ShowRecordAsync(id, request);
            return Ok(_responseOutputPort.Content);
        }

        [HttpPost("newItem")]
        public async Task<ActionResult<IResponseResult>> CreateCurrencyAsync([FromBody] RequestCatalogDto request)
        {
            await _catalogUseCaseInputPort.CreateRecordAsync(request);
            return Created("", _responseOutputPort.Content);
        }

        [HttpPut("modifyItem")]
        public async Task<ActionResult<IResponseResult>> EditCurrencyAsync([FromBody] RequestByModifyCatalogDto request)
        {
            await _catalogUseCaseInputPort.EditRecordAsync(request);
            return Ok(_responseOutputPort.Content);
        }

        [HttpDelete("clearOffItem/{id:int}")]
        public async Task<ActionResult<IResponseResult>> DeleteCurrencyAsync(int id, [FromBody] RequestByModifyCatalogDto request)
        {
            await _catalogUseCaseInputPort.DeleteRecordAsync(id, request);
            return Ok(_responseOutputPort.Content);
        }
    }
}

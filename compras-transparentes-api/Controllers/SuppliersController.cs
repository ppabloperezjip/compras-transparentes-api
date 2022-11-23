using Compras.Repository.Eums;
using Compras.Repository.Models;
using Compras.Repository.Services;
using Microsoft.AspNetCore.Mvc;

namespace compras_transparentes_api.Controllers;

[ApiController]
[Route("[controller]")]
public class SuppliersController:ControllerBase
{
    
    private readonly ISuppliersService _suppliersService;

    public SuppliersController(ISuppliersService suppliersService)
    {
        _suppliersService = suppliersService;
    }
    
    [HttpGet]
    [Route("GetTotals")]
    public async Task<IActionResult> GetTotals( int year, int periodo)
    {
        var items = await _suppliersService.GetTotals(year, periodo);

        if (!string.IsNullOrEmpty(_suppliersService.LastError))
        {
            return StatusCode(500, _suppliersService.LastError);
        }

        return Ok(items);
    }
    
    [HttpGet]
    [Route("GetTotalsBySupplier")]
    public async Task<IActionResult> GetTotalsBySupplier(int proveedorId, int year, int periodo)
    {
        var items = await _suppliersService.GetTotalsBySupplier(proveedorId, year, periodo);

        if (!string.IsNullOrEmpty(_suppliersService.LastError))
        {
            return StatusCode(500, _suppliersService.LastError);
        }

        return Ok(items);
    }

    [HttpGet]
    [Route("GetChart")]
    public async Task<IActionResult> GetChart(int proveedorId, int year, int periodo, int tipoGrafica)
    {
        var items = await _suppliersService.GetChart(proveedorId, year, periodo, tipoGrafica);

        if (!string.IsNullOrEmpty(_suppliersService.LastError))
        {
            return StatusCode(500, _suppliersService.LastError);
        }

        return Ok(items);
    }

    [HttpPost]
    [Route("GetSearch")]
    public async Task<IActionResult> GetSearch(SearchFilter filter)
    {
        filter.TipoProcedimiento = filter.TipoProcedimiento ?? ProcedureType.Todos;
        filter.TipoContratacion = filter.TipoContratacion ?? ContractType.Todos;
        var items = await _suppliersService.GetSearch(filter);

        if (!string.IsNullOrEmpty(_suppliersService.LastError))
        {
            return StatusCode(500, _suppliersService.LastError.ToString());
        }

        var model = new
        {
            total= items.cantidadProveedores,
            paginaActual = items.paginaActual,
            cantidadPaginas = items.cantidadPaginas,
            montoTotal = items.montoTotal,
            data = items.proveedores,
        };
        return Ok(model);
    }
}
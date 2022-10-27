using Compras.Repository.Eums;
using Compras.Repository.Models;
using Compras.Repository.Services;
using Microsoft.AspNetCore.Mvc;

namespace compras_transparentes_api.Controllers;

[ApiController]
[Route("[controller]")]
public class LicitacionesController:ControllerBase
{
    
    private readonly ILicitacionesService _licitacionesService;

    public LicitacionesController(ILicitacionesService licitacionesService)
    {
        _licitacionesService = licitacionesService;
    }
    
    // [HttpGet]
    // [Route("GetTotals")]
    // public async Task<IActionResult> GetTotals( int year, int periodo)
    // {
    //     var items = await _suppliersService.GetTotals(year, periodo);
    //
    //     if (!string.IsNullOrEmpty(_suppliersService.LastError))
    //     {
    //         return StatusCode(500, _suppliersService.LastError);
    //     }
    //
    //     return Ok(items);
    // }
    
    [HttpPost]
    [Route("GetSearch")]
    public async Task<IActionResult> GetSearch(SearchFilter filter)
    {
        filter.TipoProcedimiento = filter.TipoProcedimiento ?? ProcedureType.Todos;
        filter.TipoContratacion = filter.TipoContratacion ?? ContractType.Todos;
        var items = await _licitacionesService.GetSearch(filter);

        if (!string.IsNullOrEmpty(_licitacionesService.LastError))
        {
            return StatusCode(500, _licitacionesService.LastError.ToString());
        }

        var model = new
        {
            total= items.cantidadLicitaciones,
            paginaActual = items.paginaActual,
            cantidadPaginas = items.cantidadPaginas,
            montoTotal = items.montoTotal,
            data = items.licitaciones,
        };
        return Ok(model);
    }
}
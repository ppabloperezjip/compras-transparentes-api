using Compras.Repository.Eums;
using Compras.Repository.Models;
using Compras.Repository.Services;
using Microsoft.AspNetCore.Mvc;

namespace compras_transparentes_api.Controllers;

[ApiController]
[Route("[controller]")]
public class AdministrativeUnitsController:ControllerBase
{
    
    private readonly IAdministrativeUnitsService _administrativeUnitsService;

    public AdministrativeUnitsController(IAdministrativeUnitsService administrativeUnitsService)
    {
        _administrativeUnitsService = administrativeUnitsService;
    }
    
    
    [HttpGet]
    [Route("GetTopUnits")]
    public async Task<IActionResult> GetTopUnits(int? year,int? periodo,DistributionTypes? tipoDistribucion,int? limit)
    {
        var items = await _administrativeUnitsService.GetTopUnits( 
            year.HasValue ? year.Value : 0,
            periodo.HasValue ? periodo.Value : 0,
            tipoDistribucion.HasValue ? tipoDistribucion.Value  : DistributionTypes.Cantidad,
            limit.HasValue ? limit.Value : 10);

        if (!string.IsNullOrEmpty(_administrativeUnitsService.LastError))
        {
            return StatusCode(500, _administrativeUnitsService.LastError.ToString());
        }
       
        return Ok(items);
    }
    
    [HttpPost]
    [Route("GetSearchUnit")]
    public async Task<IActionResult> GetSearchUnit(SearchFilter filter)
    {
        filter.TipoProcedimiento = filter.TipoProcedimiento ?? ProcedureType.Todos;
        filter.TipoContratacion = filter.TipoContratacion ?? ContractType.Todos;
        var items = await _administrativeUnitsService.GetSearch(filter);

        if (!string.IsNullOrEmpty(_administrativeUnitsService.LastError))
        {
            return StatusCode(500, _administrativeUnitsService.LastError.ToString());
        }

        var model = new
        {
            total= items.cantidadUnidades,
            paginaActual = items.paginaActual,
            cantidadPaginas = items.cantidadPaginas,
            montoTotal = items.montoTotal,
            data = items.Unidades,
        };
        return Ok(model);
    }
}
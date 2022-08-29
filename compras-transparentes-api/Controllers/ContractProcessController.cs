using Compras.Repository.Eums;
using Compras.Repository.Models;
using Compras.Repository.Services;
using Microsoft.AspNetCore.Mvc;

namespace compras_transparentes_api.Controllers;

[ApiController]
[Route("[controller]")]
public class ContractProcessController:ControllerBase
{
    
    private readonly IContratacionesService _contratacionesService;

    public ContractProcessController(IContratacionesService contratacionesService)
    {
        _contratacionesService = contratacionesService;
    }
    
    [HttpGet]
    [Route("GetYears")]
    public IEnumerable<string> GetYears()
    {
        var items =  _contratacionesService.GetYears();
        return items;
    }
    
    [HttpGet]
    [Route("GetTotals")]
    public async Task<IActionResult> GetTotals(int? year,int? periodo)
    {
        var items = await _contratacionesService.GetTotals( year.HasValue ? year.Value : 0,periodo.HasValue ? periodo.Value : 0);

        if (!string.IsNullOrEmpty(_contratacionesService.LastError))
        {
            return StatusCode(500, _contratacionesService.LastError.ToString());
        }
       
        return Ok(items);
    }
    
    [HttpGet]
    [Route("GetCharts")]
    public async Task<IActionResult> GetCharts(int? year,int? periodo,ChartTypes? tipoGrafica)
    {
        var items = await _contratacionesService.GetChart( 
            year ?? 0,
            periodo ?? 0,
            tipoGrafica ?? ChartTypes.Procedimento);

        if (!string.IsNullOrEmpty(_contratacionesService.LastError))
        {
            return StatusCode(500, _contratacionesService.LastError.ToString());
        }
       
        return Ok(items);
    }
    
    [HttpPost]
    [Route("GetSearch")]
    public async Task<IActionResult> GetSearch(SearchFilter filter)
    {
        filter.TipoProcedimiento = filter.TipoProcedimiento ?? ProcedureType.Todos;
        filter.TipoContratacion = filter.TipoContratacion ?? ContractType.Todos;
        var items = await _contratacionesService.GetSearch(filter);

        if (!string.IsNullOrEmpty(_contratacionesService.LastError))
        {
            return StatusCode(500, _contratacionesService.LastError.ToString());
        }
        return Ok(items);
    }
}
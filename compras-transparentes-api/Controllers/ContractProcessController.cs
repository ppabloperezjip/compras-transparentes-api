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

    [HttpGet]
    [Route("GetTopSuppliers")]
    public async Task<IActionResult> GetTopSuppliers(int? year, int? periodo, int? tipoDistribucion, int limit = 10)
    {
        var items = await _contratacionesService.GetTopSuppliers(year, periodo, tipoDistribucion ?? 0, limit);

        if (!string.IsNullOrEmpty(_contratacionesService.LastError))
        {
            return StatusCode(500, _contratacionesService.LastError.ToString());
        }

        return Ok(items);
    }

    [HttpGet]
    [Route("GetDetails")]
    public async Task<IActionResult> GetDetails(int id)
    {
        var model = await _contratacionesService.GetDetails(id);

        if (!string.IsNullOrEmpty(_contratacionesService.LastError))
        {
            return StatusCode(500, _contratacionesService.LastError.ToString());
        }

        return Ok(model);
    }

    [HttpGet]
    [Route("GetLast12MonthsContracts")]
    public async Task<IActionResult> GetLast12MonthsContracts(int year, int periodo)
    {
        var model = await _contratacionesService.GetLast12MonthsContracts(year, periodo);

        if (!string.IsNullOrEmpty(_contratacionesService.LastError))
        {
            return StatusCode(500, _contratacionesService.LastError.ToString());
        }

        return Ok(model);
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

        var model = new
        {
            total= items.cantidadContratos,
            paginaActual = items.paginaActual,
            cantidadPaginas = items.cantidadPaginas,
            montoTotal = items.montoTotal,
            data = items.contratos,
        };
        return Ok(model);
    }

    [HttpGet]
    [Route("GetTotalsUA")]
    public async Task<IActionResult> GetTotalsUA(int? year, int? periodo)
    {
        var model = await _contratacionesService.GetTotalsUA(year ?? DateTime.Now.Year, periodo ?? 0);

        if (!string.IsNullOrEmpty(_contratacionesService.LastError))
        {
            return StatusCode(500, _contratacionesService.LastError.ToString());
        }

        return Ok(model);
    }

    [HttpGet]
    [Route("GetTotalsOpenData")]
    public async Task<IActionResult> GetTotalsOpenData()
    {
        var model = await _contratacionesService.GetTotalsOpenData();

        if (!string.IsNullOrEmpty(_contratacionesService.LastError))
        {
            return StatusCode(500, _contratacionesService.LastError.ToString());
        }

        return Ok(model);
    }
}
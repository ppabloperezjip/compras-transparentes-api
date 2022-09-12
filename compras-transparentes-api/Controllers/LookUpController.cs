using Compras.Repository.Eums;
using Compras.Repository.Models;
using Compras.Repository.Services;
using Microsoft.AspNetCore.Mvc;

namespace compras_transparentes_api.Controllers;

[ApiController]
[Route("[controller]")]
public class LookUpController:ControllerBase
{
    private readonly ILookUpService _lookUpService;

    public LookUpController(ILookUpService lookUpService)
    {
        _lookUpService = lookUpService;
    }
    
    [HttpGet]
    [Route("GetAutocompletNoLicitacion")]
    public async Task<IActionResult> GetAutocompletNoLicitacion(string term,int top = 10)
    {
        var items = await _lookUpService.GetAutocompletNoLicitacion(term,top);

        if (!string.IsNullOrEmpty(_lookUpService.LastError))
        {
            return StatusCode(500, _lookUpService.LastError.ToString());
        }
       
        return Ok(items);
    }
    
    [HttpGet]
    [Route("GetAutocompletProveedor")]
    public async Task<IActionResult> GetAutocompletProveedor(string term,int top = 10)
    {
        var items = await _lookUpService.GetAutocompletProveedor(term,top);

        if (!string.IsNullOrEmpty(_lookUpService.LastError))
        {
            return StatusCode(500, _lookUpService.LastError.ToString());
        }
       
        return Ok(items);
    }
    
    [HttpGet]
    [Route("GetAutocompletUnits")]
    public async Task<IActionResult> GetAutocompletUnits(string term,int top = 10)
    {
        var items = await _lookUpService.GetAutocompletUnits(term,top);

        if (!string.IsNullOrEmpty(_lookUpService.LastError))
        {
            return StatusCode(500, _lookUpService.LastError.ToString());
        }
       
        return Ok(items);
    }
    
    [HttpGet]
    [Route("GetMontoMinAndMax")]
    public async Task<IActionResult> GetMontoMinAndMax(string year)
    {
        var items = await _lookUpService.GetMontoMinAndMax(year);

        if (!string.IsNullOrEmpty(_lookUpService.LastError))
        {
            return StatusCode(500, _lookUpService.LastError.ToString());
        }
       
        return Ok(items);
    }
    
    [HttpGet]
    [Route("GetTotalProcedimientos")]
    public async Task<IActionResult> GetTotalProcedimientos(string year)
    {
        var items = await _lookUpService.GetTotalProcedimientos(year);

        if (!string.IsNullOrEmpty(_lookUpService.LastError))
        {
            return StatusCode(500, _lookUpService.LastError.ToString());
        }
        return Ok(items);
    }
}
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
}
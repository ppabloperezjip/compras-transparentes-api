using Compras.Repository.Eums;
using Compras.Repository.HelperClasses;
using Compras.Repository.Models;
using Compras.Repository.Services;
using Microsoft.AspNetCore.Mvc;
using Razor.Templating.Core;

namespace compras_transparentes_api.Controllers;

[ApiController]
[Route("[controller]")]
public class EmailsController:Controller
{
    
    private readonly IEmailsService _emailsService;

    public EmailsController(IEmailsService emailsService)
    {
        _emailsService = emailsService;
    }
    
    [HttpPost]
    [Route("Send")]
    public async Task<IActionResult> Send(EmailDto email)
    {

        email.MessageBody = await RazorTemplateEngine.RenderAsync("~/Views/EmailTemplate/_EmailTemplate.cshtml",email);
        var items = await _emailsService.Send(email);
        
        if (!string.IsNullOrEmpty(_emailsService.LastError))
        {
            return StatusCode(500, _emailsService.LastError);
        }
        
        var model = new
        {
            response=items
        };

        return Ok(model);
    }
   
}
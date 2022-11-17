using Compras.Repository.Eums;
using Compras.Repository.HelperClasses;
using Compras.Repository.Models;
using Microsoft.Extensions.Configuration;
using RestSharp;
using Compras.Repository.Helpers;

namespace Compras.Repository.Services;

public interface IEmailsService : IServiceBase
{
    Task<string> Send(EmailDto emaildtos);
}

public class EmailsService : ServiceBase,IEmailsService
{
    private RestClient _client;
    public EmailsService(IConfiguration configuration ) : base(configuration)
    {
        _client = new RestClient(configuration.GetConnectionString("baseUrl"));;
    }
    
    public async Task<string> Send(EmailDto emaildto)
    {
        try
        {
            
            var response = HelpMethods.SendEmail(emaildto);
            if (response.Result == Result.OK)
            {
                return "Se envio el correo electronico.";
            }
        }
        catch (Exception e)
        {
            LastError = "Problema al enviar corre electronico.";
        }
        return "No se pudo enviar el corre electronico";
    }
}

using Compras.Repository.Eums;
using Compras.Repository.Models;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace Compras.Repository.Services;

public interface IAdministrativeUnitsService : IServiceBase
{
    Task<List<Charts>> GetTopUnits(int year,int periodo,DistributionTypes tipoDistribucion,int limit);
}

public class AdministrativeUnitsService : ServiceBase,IAdministrativeUnitsService
{
    private RestClient _client;
    public AdministrativeUnitsService(IConfiguration configuration ) : base(configuration)
    {
        _client = new RestClient(configuration.GetConnectionString("baseUrl"));;
    }
    
    public async Task<List<Charts>> GetTopUnits(int year,int periodo,DistributionTypes tipoDistribucion,int limit)
    {
        try
        {
            var request = new RestRequest("Chart/GetTopUnits", Method.Get);
            request.AddParameter("year", year);
            request.AddParameter("periodo", periodo);
            request.AddParameter("tipoDistribucion", (int)tipoDistribucion);
            request.AddParameter("limit", limit);

            request.Timeout = 5000;
            var response = await _client.ExecuteAsync<List<Charts>>(request);

            if (response.IsSuccessStatusCode)
            {
                return response.Data;
            }
           

        }
        catch (Exception e)
        {
            LastError = "Problema al traer los valores de la grafica tipo de unidad administrativa.";
        }
        return new List<Charts>();
    }
}

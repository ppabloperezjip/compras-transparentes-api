using Compras.Repository.Eums;
using Compras.Repository.Models;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace Compras.Repository.Services;

public interface IContratacionesService : IServiceBase
{
    IEnumerable<string> GetYears();
    Task<Totals> GetTotals(int year, int periodo);
    Task<List<Charts>> GetChart(int year, int periodo, ChartTypes tipoGrafica);
}

public class ContratacionesService : ServiceBase,IContratacionesService
{
    private RestClient _client;
    public ContratacionesService(IConfiguration configuration) : base(configuration)
    {
        _client = new RestClient(configuration.GetConnectionString("baseUrl"));;
    }
    
    public IEnumerable<string> GetYears()
    {
        try
        {
            return new List<string>();

        }
        catch (Exception e)
        {
            LastError = "Problema al traer los años de las contrataciones";
            return null;
        }
    }
    
    public async Task<Totals> GetTotals(int year,int periodo)
    {
        try
        {
            var request = new RestRequest("Dashboard", Method.Get);
            request.AddParameter("year", year);
            request.AddParameter("periodo", periodo);

            request.Timeout = 5000;
            var response = await _client.ExecuteAsync<Totals>(request);

            if (response.IsSuccessStatusCode)
            {
                return response.Data;
            }

        }
        catch (Exception e)
        {
            LastError = "Problema al traer los totales de las contrataciones";

        }

        return new Totals();
    }
    
    public async Task<List<Charts>> GetChart(int year,int periodo,ChartTypes tipoGrafica)
    {
        try
        {
            var request = new RestRequest("Chart", Method.Get);
            request.AddParameter("year", year);
            request.AddParameter("periodo", periodo);
            request.AddParameter("tipoGrafica", (int)tipoGrafica);

            request.Timeout = 5000;
            var response = await _client.ExecuteAsync<List<Charts>>(request);

            if (response.IsSuccessStatusCode)
            {
                return response.Data;
            }
            

        }
        catch (Exception e)
        {
            LastError = "Problema al traer los valores de la grafica de las contrataciones";
            return null;
        }
        return new List<Charts>();
    }
}

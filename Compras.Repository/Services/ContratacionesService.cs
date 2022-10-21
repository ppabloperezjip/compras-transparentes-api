using System.Text.Json;
using Compras.Repository.Dtos;
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
    Task<List<Charts>> GetTopSuppliers(int? year, int? periodo, int tipoDistribucion, int limit = 10);
    Task<ContractDetailsDto> GetDetails(int id);
    Task<SearchDetails> GetSearch(SearchFilter filter);
    Task<List<Charts>> GetLast12MonthsContracts();
    Task<Totals> GetTotalsUA(int year, int periodo);
}

public class ContratacionesService : ServiceBase,IContratacionesService
{
    private RestClient _client;
    public ContratacionesService(IConfiguration configuration) : base(configuration)
    {
        _client = new RestClient(configuration.GetConnectionString("baseUrl"));
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
    
    public async Task<Totals> GetTotalsUA(int year,int periodo)
    {
        try
        {
            var request = new RestRequest("Dashboard/GetDashboardUC", Method.Get);
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
    
    public async Task<List<Charts>> GetTopSuppliers(int? year, int? periodo, int tipoDistribucion, int limit = 10)
    {
        try
        {
            var request = new RestRequest("Chart/GetTopSuppliers", Method.Get);
            if(year is not null)
                request.AddParameter("year", year.Value);
            
            if(periodo is not null)
                request.AddParameter("periodo", periodo.Value);

            request.AddParameter("tipoDistribucion", tipoDistribucion);
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
            LastError = "Problema al traer los valores de la grafica de las contrataciones";
            return null;
        }
        return new List<Charts>();
    }
    
    public async Task<List<Charts>> GetLast12MonthsContracts()
    {
        try
        {
            var request = new RestRequest("Chart/GetLast12MonthsContracts", Method.Get);

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
    
    public async Task<SearchDetails> GetSearch(SearchFilter filter)
    {
        try
        {
            var parm = filter.page.HasValue && filter.pageSize.HasValue
                ? $"?page={filter.page.Value}&pageSize={filter.pageSize.Value}"
                : "";
            var request = new RestRequest($"SearchResults/ListadoInicio{parm}", Method.Post);
            string jsonString = JsonSerializer.Serialize(filter);
            request.AddParameter("application/json", jsonString, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            
            request.Timeout = 5000;
            var response = await _client.ExecuteAsync<SearchDetails>(request);

            if (response.IsSuccessStatusCode)
            {
                return response.Data;
            }
        }
        catch (Exception e)
        {
            LastError = "Problema al traer los de la busqueda de contrataciones";
            return new SearchDetails();
        }
        return new SearchDetails();
    }

    public async Task<ContractDetailsDto> GetDetails(int id)
    {
        try
        {
            var request = new RestRequest("SearchResults/GetContratacionById", Method.Get);
            request.AddParameter("id", id);

            request.Timeout = 5000;
            var response = await _client.ExecuteAsync<ContractDetailsDto>(request);

            if (response.IsSuccessStatusCode)
            {
                return response.Data;
            }
        }
        catch (Exception e)
        {
            LastError = "Problema al traer los detalles de la contratacion";
            return null;
        }
        return null;
    }
}

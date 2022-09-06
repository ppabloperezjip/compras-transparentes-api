using Compras.Repository.Eums;
using Compras.Repository.Models;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace Compras.Repository.Services;

public interface ILookUpService : IServiceBase
{
    Task<List<LookUp>> GetAutocompletNoLicitacion(string term, int top);
    Task<List<LookUp>> GetAutocompletProveedor(string term, int top);
    Task<List<LookUp>> GetAutocompletUnits(string term, int top);
    Task<List<LookUp>> GetMontoMinAndMax(string year);
    Task<int> GetTotalProcedimientos(string year);
}

public class LookUpService : ServiceBase,ILookUpService
{
    private RestClient _client;
    public LookUpService(IConfiguration configuration ) : base(configuration)
    {
        _client = new RestClient(configuration.GetConnectionString("baseUrl"));;
    }
    
    public async Task<List<LookUp>> GetAutocompletNoLicitacion(string term,int top)
    {
        try
        {
            var request = new RestRequest("LookUp/GetAutocompletNoLicitacion", Method.Get);
            request.AddParameter("term", term);
            request.AddParameter("top", top);

            request.Timeout = 5000;
            var response = await _client.ExecuteAsync<List<LookUp>>(request);

            if (response.IsSuccessStatusCode)
            {
                return response.Data;
            }
           

        }
        catch (Exception e)
        {
            LastError = "Problema al traer los valores del catalogo de numero de licitaciones.";
        }
        return new List<LookUp>();
    }
    
    public async Task<List<LookUp>> GetAutocompletProveedor(string term,int top)
    {
        try
        {
            var request = new RestRequest("LookUp/GetAutocompletProveedor", Method.Get);
            request.AddParameter("term", term);
            request.AddParameter("top", top);

            request.Timeout = 5000;
            var response = await _client.ExecuteAsync<List<LookUp>>(request);

            if (response.IsSuccessStatusCode)
            {
                return response.Data;
            }
           

        }
        catch (Exception e)
        {
            LastError = "Problema al traer los valores del catalogo de numero de licitaciones.";
        }
        return new List<LookUp>();
    }
    
    public async Task<List<LookUp>> GetAutocompletUnits(string term,int top)
    {
        try
        {
            var request = new RestRequest("LookUp/GetAutocompletUnits", Method.Get);
            request.AddParameter("term", term);
            request.AddParameter("top", top);

            request.Timeout = 5000;
            var response = await _client.ExecuteAsync<List<LookUp>>(request);

            if (response.IsSuccessStatusCode)
            {
                return response.Data;
            }
           

        }
        catch (Exception e)
        {
            LastError = "Problema al traer los valores del catalogo de numero de licitaciones.";
        }
        return new List<LookUp>();
    }
    
    public async Task<List<LookUp>> GetMontoMinAndMax(string year)
    {
        try
        {
            var request = new RestRequest("LookUp/GetMontoMinAndMax", Method.Get);
            request.AddParameter("year", year);

            request.Timeout = 5000;
            var response = await _client.ExecuteAsync<List<LookUp>>(request);

            if (response.IsSuccessStatusCode)
            {
                return response.Data;
            }
           

        }
        catch (Exception e)
        {
            LastError = "Problema al traer los valores del catalogo de monto maximo y minimo.";
        }
        return new List<LookUp>();
    }
    
    public async Task<int> GetTotalProcedimientos(string year)
    {
        try
        {
            var request = new RestRequest("LookUp/GetTotalProcedimientos", Method.Get);
            request.AddParameter("year", year);

            request.Timeout = 5000;
            var response = await _client.ExecuteAsync<int>(request);

            if (response.IsSuccessStatusCode)
            {
                return response.Data;
            }
           

        }
        catch (Exception e)
        {
            LastError = "Problema al traer los valores del catalogo de rango/monto total de procedimientos.";
        }
        return 0;
    }
}

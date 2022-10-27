using Compras.Repository.Eums;
using Compras.Repository.Models;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System.Text.Json;

namespace Compras.Repository.Services;

public interface ILicitacionesService : IServiceBase
{
    Task<TotalsLicitaciones> GetTotals(int year, int periodo);
    Task<SearchLicitacion> GetSearch(SearchFilter filter);
}

public class LicitacionesService : ServiceBase,ILicitacionesService
{
    private RestClient _client;
    public LicitacionesService(IConfiguration configuration ) : base(configuration)
    {
        _client = new RestClient(configuration.GetConnectionString("baseUrl"));;
    }

    public async Task<TotalsLicitaciones> GetTotals(int year, int periodo)
    {
        try
        {
            var request = new RestRequest("Dashboard/GetDashboardEstatusLicitaciones", Method.Get);
            request.AddParameter("year", year);
            request.AddParameter("periodo", periodo);

            request.Timeout = 5000;
            var response = await _client.ExecuteAsync<TotalsLicitaciones>(request);

            if (response.IsSuccessStatusCode)
            {
                return response.Data;
            }
        }
        catch (Exception e)
        {
            LastError = "Problema al traer los valores de los totales por licitaciones.";
        }
        return new TotalsLicitaciones();
    }

    public async Task<SearchLicitacion> GetSearch(SearchFilter filter)
    {
        try
        {
            var parm = filter.page.HasValue && filter.pageSize.HasValue
                ? $"?page={filter.page.Value}&pageSize={filter.pageSize.Value}"
                : "";
            var request = new RestRequest($"SearchResults/ListadoLicitaciones{parm}", Method.Post);
            string jsonString = JsonSerializer.Serialize(filter);
            request.AddParameter("application/json", jsonString, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            
            request.Timeout = 5000;
            var response = await _client.ExecuteAsync<SearchLicitacion>(request);

            if (response.IsSuccessStatusCode)
            {
                return response.Data;
            }
        }
        catch (Exception e)
        {
            LastError = "Problema al traer los de la busqueda de Proveedores";
            return new SearchLicitacion();
        }
        return new SearchLicitacion();
    }
}

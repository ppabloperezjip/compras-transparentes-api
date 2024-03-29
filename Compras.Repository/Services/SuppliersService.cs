using Compras.Repository.Eums;
using Compras.Repository.Models;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System.Text.Json;

namespace Compras.Repository.Services;

public interface ISuppliersService : IServiceBase
{
    Task<TotalBySupplierDetails> GetTotalsBySupplier(int proveedorId, int year, int periodo);
    Task<TotalsBySuppliers> GetTotals(int year, int periodo);
    Task<SearchSuppliers> GetSearch(SearchFilter filter);
    Task<List<Charts>> GetChart(int proveedorId, int year, int periodo, int tipoGrafica);
}

public class SuppliersService : ServiceBase,ISuppliersService
{
    private RestClient _client;
    public SuppliersService(IConfiguration configuration ) : base(configuration)
    {
        _client = new RestClient(configuration.GetConnectionString("baseUrl"));;
    }
    
    public async Task<TotalBySupplierDetails> GetTotalsBySupplier(int proveedorId, int year, int periodo)
    {
        try
        {
            var request = new RestRequest("Dashboard/GetDashboardSupplierDetails", Method.Get);
            request.AddParameter("proveedorId", proveedorId);
            request.AddParameter("year", year);
            request.AddParameter("periodo", periodo);

            request.Timeout = 10000;
            var response = await _client.ExecuteAsync<TotalBySupplierDetails>(request);

            if (response.IsSuccessStatusCode)
            {
                return response.Data;
            }
        }
        catch (Exception e)
        {
            LastError = "Problema al traer los valores de los totales por proveedor.";
        }
        return new TotalBySupplierDetails();
    }
    
    public async Task<TotalsBySuppliers> GetTotals(int year, int periodo)
    {
        try
        {
            var request = new RestRequest("Dashboard/GetDashboardSupplier", Method.Get);
            request.AddParameter("year", year);
            request.AddParameter("periodo", periodo);

            request.Timeout = 10000;
            var response = await _client.ExecuteAsync<TotalsBySuppliers>(request);

            if (response.IsSuccessStatusCode)
            {
                return response.Data;
            }
        }
        catch (Exception e)
        {
            LastError = "Problema al traer los valores de los totales por proveedor.";
        }
        return new TotalsBySuppliers();
    }
    
    public async  Task<SearchSuppliers> GetSearch(SearchFilter filter)
    {
        try
        {
            var parm = filter.page.HasValue && filter.pageSize.HasValue
                ? $"?page={filter.page.Value}&pageSize={filter.pageSize.Value}"
                : "";
            var request = new RestRequest($"SearchResults/ListadoProveedores{parm}", Method.Post);
            string jsonString = JsonSerializer.Serialize(filter);
            request.AddParameter("application/json", jsonString, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            
            request.Timeout = 10000;
            var response = await _client.ExecuteAsync<SearchSuppliers>(request);

            if (response.IsSuccessStatusCode)
            {
                return response.Data;
            }
        }
        catch (Exception e)
        {
            LastError = "Problema al traer los de la busqueda de Proveedores";
            return new SearchSuppliers();
        }
        return new SearchSuppliers();
    }

    public async Task<List<Charts>> GetChart(int proveedorId, int year, int periodo, int tipoGrafica)
    {
        try
        {
            var request = new RestRequest("Chart/GetSupplierDashboardChart", Method.Get);
            request.AddParameter("proveedorId", proveedorId);
            request.AddParameter("year", year);
            request.AddParameter("periodo", periodo);
            request.AddParameter("tipoGrafica", tipoGrafica);

            request.Timeout = 10000;
            var response = await _client.ExecuteAsync<List<Charts>>(request);

            if (response.IsSuccessStatusCode)
            {
                return response.Data;
            }
        }
        catch (Exception e)
        {
            LastError = "Problema al traer los valores de los totales por unidad administrativa.";
        }
        return new List<Charts>();
    }
}

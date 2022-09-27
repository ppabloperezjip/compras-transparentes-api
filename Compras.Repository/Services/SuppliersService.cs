using Compras.Repository.Eums;
using Compras.Repository.Models;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System.Text.Json;

namespace Compras.Repository.Services;

public interface ISuppliersService : IServiceBase
{
    Task<TotalsBySuppliers> GetTotals(int year, int periodo);
}

public class SuppliersService : ServiceBase,ISuppliersService
{
    private RestClient _client;
    public SuppliersService(IConfiguration configuration ) : base(configuration)
    {
        _client = new RestClient(configuration.GetConnectionString("baseUrl"));;
    }
    
    public async Task<TotalsBySuppliers> GetTotals(int year, int periodo)
    {
        try
        {
            var request = new RestRequest("Dashboard/GetDashboardSupplier", Method.Get);
            request.AddParameter("year", year);
            request.AddParameter("periodo", periodo);

            request.Timeout = 5000;
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
}

using System.Data.Entity;
using Microsoft.Extensions.Options;

namespace compras_transparentes_api;

public class ComprasDbContext: DbContext
{
    public ComprasDbContext() : base("mssql")
    {
        
    }
}
namespace Compras.Repository;

using Microsoft.Extensions.Configuration;

public  interface IServiceBase {

    string LastError { get; }
}

public class ServiceBase : IServiceBase
{ 
    public string LastError { get; protected set; }
    public ServiceBase(IConfiguration configuration){
    
    }
}
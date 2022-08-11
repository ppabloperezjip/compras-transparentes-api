namespace Compras.Repository;
using Microsoft.Extensions.Configuration;


public  interface IRepositoryBase {

}

public class RepositoryBase : IRepositoryBase
{
       
    public RepositoryBase(IConfiguration configuration){
    
    }
    
}
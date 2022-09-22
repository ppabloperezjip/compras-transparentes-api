using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Compras.Repository.Eums;
using Newtonsoft.Json;

namespace Compras.Repository.Models;

public class SearchDetails
{
    public int cantidadContratos { get; set; }
    public int paginaActual { get; set; }
    public int cantidadPaginas { get; set; }
    public string montoTotal { get; set; }
    public List<ContractDto> contratos { get; set; }
    
}

public class SearchDetailsUnit
{
    public int cantidadUnidades { get; set; }
    public int paginaActual { get; set; }
    public int cantidadPaginas { get; set; }
    public string montoTotal { get; set; }
    public List<UnitDto> Unidades { get; set; }
}

public class SearchFilter
{
    public string ConceptoContrato { get; set; }
    public string Clasificaciones { get; set; }
    public int Year { get; set; }
    public Trimestres Trimestre { get; set; }
    public string UnidadCompradora { get; set; }
    public int OrganismoId { get; set; }
    public string Proveedor { get; set; }
    public int ProveedorId { get; set; }
    public ProcedureType? TipoProcedimiento { get; set; } //this is -1 for all
    public string NumeroLicitacion { get; set; }
    public ContractType? TipoContratacion { get; set; } //this is -1 for all
    public string FechaInicial { get; set; } //2015-01-01
    public string FechaFinal { get; set; } //2022-12-31
    public double MontoMinimo { get; set; } 
    public double MontoMaximo { get; set; } 
    public double MinimoContrato { get; set; } 
    public double MaximoContrato { get; set; } 
    public string OrderColumn { get; set; } 
    public string OrderOrientation { get; set; } 
    public int page { get; set; }
    public int pageSize { get; set; } 
    
}
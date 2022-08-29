namespace Compras.Repository.Models;

public class ContractDto
{
    public int contratacionId { get; set; }
    public string numeroLicitacion { get; set; }
    public string tipoContratacion { get; set; }
    public string tipoProcedimiento { get; set; }
    public string unidadCompradora { get; set; }
    public string clasificacion { get; set; }
    public string conceptoContrato { get; set; }
    public int proveedorId { get; set; }
    public string prveedorNombre { get; set; }
    public double montoContrato { get; set; }
}
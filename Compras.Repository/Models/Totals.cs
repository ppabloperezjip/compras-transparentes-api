namespace Compras.Repository.Models;

public class Totals
{
    public double Monto { get; set; }
    public int CantidadUnidadesCompradoras { get; set; }
    public int CantidadProveedores { get; set; }
    public int CantidadContratos { get; set; }
    public int FiscalYear { get; set; }
    public int Periodo { get; set; }
    public decimal porcentajeVariacion { get; set; }
    public int variacion { get; set; }
    
    // "monto": 530805222.13,
    // "cantidadUnidadesCompradoras": 31,
    // "cantidadProveedores": 168,
    // "cantidadContratos": 242,
    // "fiscalYear": "2022",
    // "periodo": 2
}
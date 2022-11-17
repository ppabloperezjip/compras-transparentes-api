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
    public decimal porcentajePublicasYSimplificadas { get; set; }
    public int variacionPublicasYSimplificadas { get; set; }
    public decimal porcentajeAdjudicacionesDirectas { get; set; }
    public int variacionAdjudicacionesDirectas { get; set; }
    public int variacion { get; set; }
    public int cantidadPublicasYSimplificadas { get; set; }
    public int cantidadLPyLSAnterior { get; set; }
    public int cantidadAdjudicacionesDirectas { get; set; }
    public int cantidadADAnterior { get; set; }
}


public class TotalsOpenData
{
    public int cantidadProcedimientos { get; set; }
    public int cantidadProveedoresParticipantes { get; set; }
    public int cantidadAdjudicadas { get; set; }
}

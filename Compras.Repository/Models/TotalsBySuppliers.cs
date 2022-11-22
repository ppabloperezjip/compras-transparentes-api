namespace Compras.Repository.Models;

public class TotalsBySuppliers
{
    public int totalProveedores { get; set; }
    public int totalPreveedoresNuevos { get; set; }
    public int totalParticipantes { get; set; }
    public int variacion { get; set; }
    public decimal porcentajeParticipantes { get; set; }
    public int totalParticipantesAnteriores { get; set; }
}



public class TotalBySupplierDetails
{
    public int cantidadContratos { get; set; }
    public float montoTotal { get; set; }
    public float montoMinimo { get; set; }
    public float montoPromedio { get; set; }
    public float montoMaximo { get; set; }
}

namespace Compras.Repository.Models;

public class UnitDto
{
    public int organismoId { get; set; }
    public string siglas { get; set; }
    public string nombre { get; set; }
    public int cantidadProcedimientos { get; set; }
    public int procedimientosConContrato { get; set; }
    public double porcentajeConContrato { get; set; }
    public int procedimientosSinContrato { get; set; }
    public double porcentajeSinContrato { get; set; }
    public int proveedorId { get; set; }
    public string topSupplierName { get; set; }
    public int cantidadTopSupplier { get; set; }
    public double porcentajeTopSupplier { get; set; }
    public int cantidadContratos { get; set; }
    public int cantidadLPublica { get; set; }
    public double porcentajeLPublica { get; set; }
    public int cantidadLSimplificada { get; set; }
    public double porcentajeLSimplificada { get; set; }
    public int cantidadADirecta { get; set; }
    public double porcentajeADirecta { get; set; }
    public double montoMinimo { get; set; }
    public double montoPromedio { get; set; }
    public double montoMaximo { get; set; }
    public double montoTotalPorUnidad { get; set; }
}

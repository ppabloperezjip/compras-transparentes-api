namespace Compras.Repository.Models;
public class SupplierDto
{
    public int proveedorId { get; set; }
    public string rfc { get; set; }
    public string proveedorNombre { get; set; }
    public string fechaRegistro { get; set; }
    public int cantidadParticipaciones { get; set; }
    public int cantidadContratos { get; set; }
    public double porcentajeContratos { get; set; }
    public int cantidadSinContrato { get; set; }
    public double porcentajeSinContratos { get; set; }
    public int organismoId { get; set; }
    public string topUnitNombre { get; set; }
    public int topUnitCantidad { get; set; }
    public double topUnitPorcentaje { get; set; }
    public int cantidadLPublicas { get; set; }
    public double porcentajeLPublicas { get; set; }
    public int cantidadLSimplificadas { get; set; }
    public double porcentajeLSimplificadas { get; set; }
    public int cantidadADirectas { get; set; }
    public double porcentajeADirectas { get; set; }
    public double montoMinimo { get; set; }
    public double montoPromedio { get; set; }
    public double montoMaximo { get; set; }
    public double montoTotalProveedor { get; set; }
}

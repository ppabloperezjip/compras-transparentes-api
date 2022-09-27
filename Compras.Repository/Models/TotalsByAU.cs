namespace Compras.Repository.Models;

public class TotalsByAU
{
    public int cantidadContratos { get; set; }
    public decimal montoTotal { get; set; }
    public decimal? montoMinimo { get; set; }
    public decimal? montoPromedio { get; set; }
    public decimal? montoMaximo { get; set; }
}
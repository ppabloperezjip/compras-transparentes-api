namespace Compras.Repository.Models;

public class TotalsLicitaciones
{
    public int cantidadCapturadas { get; set; }
    public int cantidadVigentes { get; set; }
    public int cantidadEnSeguimiento { get; set; }
    public int cantidadAdjudicadas { get; set; }
    public int cantidadCanceladas { get; set; }
    public int cantidadCerradas { get; set; }
    public int cantidadDesiertas { get; set; }
    public int cantidadCanceladasCerradasDesiertas { get; set; }

    public int total => cantidadCapturadas + cantidadVigentes + cantidadEnSeguimiento + cantidadAdjudicadas + cantidadCanceladas + cantidadCerradas + cantidadDesiertas;

}

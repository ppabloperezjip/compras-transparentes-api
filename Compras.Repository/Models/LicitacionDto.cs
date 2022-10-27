namespace Compras.Repository.Models;

public class LicitacionDto
{
    public int contratacionId { get; set; }
    public string numeroLicitacion { get; set; }
    public string estatus { get; set; }
    public string concepto { get; set; }
    public int organismoId { get; set; }
    public string dependencia { get; set; }
    public string fechaPublicacion { get; set; }
    public string botonParticipar { get; set; }
}
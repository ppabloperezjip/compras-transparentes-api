using System.Net.Mail;

namespace Compras.Repository.Models;

public class EmailDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string? Phone { get; set; }
    public string Subject { get; set; } 
    public string SubjectMain { get; set; } = "COMPRAS TRANSPARENTES COMENTARIOS";
    public string MessageBody { get; set; }
    public List<Attachment>? lstAttachments { get; set; }
    public List<string> lstToAddress { get; set; } = new List<string> { "compranet@sonora.gob.mx" };

}
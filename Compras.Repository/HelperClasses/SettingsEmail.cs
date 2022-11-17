using System.Configuration;

namespace Compras.Repository.HelperClasses;


public class SettingsEmail
{
    public SettingsEmail()
    {
        // Email = ConfigurationManager.AppSettings["Email"];
        // Responsable = ConfigurationManager.AppSettings["Responsable"];
        // Password = ConfigurationManager.AppSettings["Password"];
        // SMTP = ConfigurationManager.AppSettings["SMTP"];
        // Port = int.Parse(ConfigurationManager.AppSettings["Port"]);
        // EnableSsl = bool.Parse(ConfigurationManager.AppSettings["EnableSsl"]);
        // "Email": "notificaciones@sonora.gob.mx",
        // "Password": "SCG.sdat19012017",
        // "SMTP": "smtp.gmail.com",
        // "Port": "587",
        // "EnableSsl": "true"
        Email = "notificaciones@sonora.gob.mx";
        Responsable = "Pablo";
        Password = "SCG.sdat19012017";
        SMTP = "smtp-legacy.office365.com";
        Port = int.Parse("587");
        EnableSsl = bool.Parse("true");
    }

    public string Email { get; set; }
    public string Responsable { get; set; }
    public string Password { get; set; }
    public string SMTP { get; set; }
    public int Port { get; set; }
    public bool EnableSsl { get; set; }
}
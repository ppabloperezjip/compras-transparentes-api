using System.Net;
using System.Net.Mail;
using Compras.Repository.HelperClasses;
using Compras.Repository.Models;

namespace Compras.Repository.Helpers;

public class HelpMethods
{
    public static Response SendEmail(EmailDto email)
    {
        Response response = new Response();
        try
        {
            var vSettingsEmail = new SettingsEmail();
            string sEmailSubject = email.SubjectMain;
            var vFromAddress = new MailAddress(vSettingsEmail.Email, vSettingsEmail.Responsable);

            MailMessage msg = new MailMessage();
            foreach (var item in email.lstToAddress)
                msg.To.Add(new MailAddress(item));

            if (email.lstAttachments?.Any() == true)
                foreach (var item in email.lstAttachments)
                    msg.Attachments.Add(item);

            msg.From = vFromAddress;
            msg.Subject = sEmailSubject;
            msg.IsBodyHtml = true;
            msg.Body = email.MessageBody;

            using (SmtpClient client = new SmtpClient())
            {
                client.EnableSsl = vSettingsEmail.EnableSsl;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(vSettingsEmail.Email, vSettingsEmail.Password);
                client.Host = vSettingsEmail.SMTP;
                client.Port = vSettingsEmail.Port;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(msg);
            }

            response.Result = Result.OK;
        }
        catch (Exception ex)
        {
            response.Data = ex.ToString();
            response.Result = Result.ERROR;
        }
        return response;
    }
}
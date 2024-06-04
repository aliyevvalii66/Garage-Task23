using BigonWebApp.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BigonWebApp.Data.Services
{
    public class MailService : IMailService
    {
        public async Task<bool> SendAsync(string to, string subject, string body, bool isHTML = true)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Credentials = new NetworkCredential("ali.aliyev200212@gmail.com", "XXXX");
                smtpClient.EnableSsl = true;
                smtpClient.Port = 587;
                smtpClient.Host = "smtp.google.com";

                MailMessage message = new MailMessage();
                message.From = new MailAddress("ali.aliyev200212@gmail.com","Bigon");
                message.Body = body;
                message.Subject = subject;
                message.IsBodyHtml = isHTML;
                message.To.Add(to);
                await smtpClient.SendMailAsync(message);
                return true;
            }
            catch (Exception)
            {

                return false;
            }

           


        }
    }
}

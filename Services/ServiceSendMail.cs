using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TAsk.Services
{
    public class ServiceSendMail
    {
        public string SendMail(string email) 
        { 
        
            Random number = new Random();
            var codigo = number.Next();

            MailMessage mailMessage = new MailMessage("Nao_Resp0nda@hotmail.com", email);
            mailMessage.Subject = "Redefinir senha";
            mailMessage.Body = $"Olá {email}\n\nEste é o código de segurança para redefiniçao de senha.\n\n\nCódigo: {codigo}";
            mailMessage.SubjectEncoding = Encoding.GetEncoding("UTF-8");
            mailMessage.BodyEncoding = Encoding.GetEncoding("UTF-8");

            SmtpClient smtpClient = new SmtpClient("smtp.office365.com", 587);
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("Nao_Resp0nda@hotmail.com", "Naoresp@");
            smtpClient.EnableSsl = true;

             smtpClient.Send(mailMessage);
             return codigo.ToString();
        }
    }
}

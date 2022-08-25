using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.NotificationMessage
{
    public class EmailSender
    {
        public void Sender(object user, IConfiguration _config)
        {
            SmtpClient smtpClient = new SmtpClient()
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                EnableSsl = true,
                Host = _config.GetValue<string>("EmailConfiguration:Host"),
                Port = _config.GetValue<int>("EmailConfiguration:Port"),
                Credentials = new NetworkCredential(_config.GetValue<string>("EmailConfiguration:Email"), _config.GetValue<string>("EmailConfiguration:Password"))
            };


            StringBuilder builder = new StringBuilder();
            builder.Append("<html>");
            builder.Append("<head><meta charset=\"utf-8\" /></head>");
            builder.Append("<body>");

            builder.Append("<table>");
            // AD - SOYAD
            builder.Append("<tr>");
            builder.Append("<td><b>AD - SOYAD : </b></td>");
            builder.Append("<td>" + user.GetType().GetProperty("FirstName").GetValue(user, null).ToString() + " " + user.GetType().GetProperty("LastName").GetValue(user, null).ToString() + "</td>");
            builder.Append("</tr>");
            // EMAIL
            builder.Append("<tr>");
            builder.Append("<td><b>EMAIL : </b></td>");
            builder.Append("<td>" + user.GetType().GetProperty("Email").GetValue(user, null).ToString() + "</td>");
            builder.Append("</tr>");
            // PHONE
            builder.Append("<tr>");
            builder.Append("<td><b>TELEFON : </b></td>");
            builder.Append("<td>" + user.GetType().GetProperty("PhoneNumber").GetValue(user, null).ToString() + "</td>");
            builder.Append("</tr>");
            // PASSWORD
            builder.Append("<tr>");
            builder.Append("<td><b>PASSWORD : </b></td>");
            builder.Append("<td>" + user.GetType().GetProperty("PasswordHash").GetValue(user, null).ToString() + "</td>");
            builder.Append("</tr>");

            builder.Append("<br />");
            builder.Append("<hr />");
            builder.Append("<br />");



            MailMessage message = new MailMessage();
            message.From = new MailAddress(_config.GetValue<string>("EmailConfiguration:Email"));
            message.To.Add(user.GetType().GetProperty("Email").GetValue(user, null).ToString());
            message.Subject = "Fatura Yönetim Sistemi Kullanıcı Kayıt Bilgileri";
            message.IsBodyHtml = true;
            message.Body = builder.ToString();


            smtpClient.Send(message);
        }

    }
}

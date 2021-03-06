﻿using System;
using System.Net;
using System.Net.Mail;
using Countries.Dal.Models.Mail;

namespace Countries.Managers.MailSender
{
    /// <summary>
    /// E-mail sending manager
    /// </summary>
    public class NetMailSender : IMailSenderStrategy
    {
        /// <summary>
        /// Send e-mail
        /// </summary>
        /// <param name="mailModel">
        /// E-mail model
        /// </param>
        public void Send(IMail mailModel)
        {
            if (mailModel == null)
                throw new ArgumentException(nameof(mailModel));

            try
            {
                using (var mail = new MailMessage())
                {
                    mail.From = new MailAddress(mailModel.From);
                    mail.To.Add(new MailAddress(mailModel.To));
                    mail.Subject = mailModel.Caption;
                    mail.Body = mailModel.Message;

                    SmtpClient client = new SmtpClient();
                    client.Host = mailModel.SmtpServer;
                    client.Port = mailModel.Port;
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential(mailModel.From.Split('@')[0], mailModel.Password);
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.Send(mail);
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Cant send mail: {e.Message}");
            }
        }
    }
}
//-----------------------------------------------------------------------
// <copyright file="Email.cs" company="Bliss Application">
// Copyright (c) Vando Moreira. All rights reserved.
// </copyright>
// <author>Vando.Moreira<author>
// WebApi - Bliss Application
//-----------------------------------------------------------------------
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace api
{
    [TestClass]
    public class Email
    {
        [TestMethod]
        public void sendEmailViaWebApi(string destinationEmail, string contentUrl)
        {
            string subject = "Web API - Challenge Bliss";
            string body = contentUrl;
            string fromMail = "from@from.com";
            string emailTo = destinationEmail;

            MailMessage mail = new MailMessage();
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

            try
            {
                //Body Email
                mail.Subject = subject;
                mail.From = new MailAddress(fromMail);
                mail.To.Add(emailTo);
                mail.Subject = "";
                mail.Body = body;

                //Server autentication
                smtpClient.EnableSsl = true;
                smtpClient.Port = 25;
                smtpClient.Credentials = new System.Net.NetworkCredential("from@from.com", "pwd");
                smtpClient.Send(mail);

            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
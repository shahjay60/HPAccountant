using HpAccountant.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace HpAccountant.Controllers
{
    public class ContactController : Controller
    {
        private string Host = ConfigurationManager.AppSettings["host"];
        private string Port = ConfigurationManager.AppSettings["port"];
        private string Email = ConfigurationManager.AppSettings["emailId"];
        private string Password = ConfigurationManager.AppSettings["password"];

        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SendEmail(Enquiry mdata)
        {
            #region SendEmail & Password
            //Log.Info("Register Mail started...");
            try
            {

                MailMessage mail = new MailMessage();
                mail.To.Add(Email);
                MailAddress address = new MailAddress(Email);
                mail.From = address;

                //   msgs.BodyEncoding = System.Text.Encoding.GetEncoding("utf-8");
                string body = string.Empty;
                mail.Subject = "Enqury details from" + mdata.Name;
                body = "Name: " + mdata.Name;
                body += "Email: " + mdata.EmailId;
                body += "Message: " + mdata.Message;
                body += "Subject: " + mdata.Subject;

                mail.Subject = "Enquiry from client";
                string Body = body;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Host = "relay-hosting.secureserver.net";
                smtp.Port = 25;
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = new System.Net.NetworkCredential(Email, Password); // Enter seders User name and password  
                smtp.EnableSsl = false;
                smtp.Send(mail);
                return Json("Ok");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);

            }


            #endregion
        }

        public ActionResult SendEnquryEmail(Enquiry mdata)
        {
            #region SendEmail & Password
            //Log.Info("Register Mail started...");
            try
            {

                //string to = "hpaccountant.com.test-google-a.com";
                //string from = mdata.EmailId;
                //MailMessage msgs = new MailMessage(from,to);

                //string body = string.Empty;

                ////   msgs.BodyEncoding = System.Text.Encoding.GetEncoding("utf-8");
                //string textBody = " <table border=" + 1 + " cellpadding=" + 0 + " cellspacing=" + 0 + " width = " + 400 + "><tr bgcolor='#4da6ff'><td><b>Column 1</b></td> <td> <b> Column 2</b> </td></tr>";

                //textBody += "<tr><td>Name: </td><td>"+mdata.Name+"</td></tr>";
                //textBody += "<tr><td>Email</td><td>" + mdata.EmailId + "</td></tr>";
                //textBody += "<tr><td>Service Name</td><td>" + mdata.Service + "</td></tr>";
                //textBody += "<tr><td>Contact number</td><td>" + mdata.Contact + "</td></tr>";
                //textBody += "<tr><td>Message</td><td>" + mdata.Message + "</td></tr>";

                //textBody += "</table>";

                //msgs.Body = textBody;
                //msgs.IsBodyHtml = true;
                //SmtpClient client = new SmtpClient();

                ////client.EnableSsl = true;
                ////client.Host = Host;
                ////client.Port = Convert.ToInt32(Port);
                //client.UseDefaultCredentials = true;
                //client.EnableSsl = true;
                ////NetworkCredential credentials = new NetworkCredential(Email, Password);

                ////Send the msgs  
                //client.Send(msgs);

                MailMessage mail = new MailMessage();
                mail.To.Add(Email);
                mail.From = new MailAddress(Email);
                string textBody = " <table border=" + 1 + " cellpadding=" + 0 + " cellspacing=" + 0 + " width = " + 400 + "><tr bgcolor='#4da6ff'><td><b>Column 1</b></td> <td> <b> Column 2</b> </td></tr>";

                textBody += "<tr><td>Name: </td><td>" + mdata.Name + "</td></tr>";
                textBody += "<tr><td>Email</td><td>" + mdata.EmailId + "</td></tr>";
                textBody += "<tr><td>Service Name</td><td>" + mdata.Service + "</td></tr>";
                textBody += "<tr><td>Contact number</td><td>" + mdata.Contact + "</td></tr>";
                textBody += "<tr><td>Message</td><td>" + mdata.Message + "</td></tr>";

                textBody += "</table>";

                mail.Subject = "Enquiry from client";
                string Body = textBody;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Host = "relay-hosting.secureserver.net";
                smtp.Port = 25;
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = new System.Net.NetworkCredential(Email, Password); // Enter seders User name and password  
                smtp.EnableSsl = false;
                smtp.Send(mail);

                return Json("Ok");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);

            }


            #endregion
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(WebApplication1.Models.EmailFormModel model)
        {
            string SenderEmail = System.Configuration.ConfigurationManager.AppSettings["SenderEmail"].ToString();
            string SenderPassword = System.Configuration.ConfigurationManager.AppSettings["SenderPassword"].ToString();

            MailMessage mailMessage = new MailMessage(SenderEmail, model.Email, model.Subject, "Thank you for reaching out to Matts Boxing regarding: <br /><br />" + model.Body + "<br /><br />We will be contacting you shortly.<br /><br />Matts Boxing<br />555-555-5555<br />mattsboxingcis4910c@gmail.com");
            mailMessage.IsBodyHtml = true;
            mailMessage.BodyEncoding = UTF8Encoding.UTF8;

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Timeout = 100000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(SenderEmail, SenderPassword);
            client.Send(mailMessage);
            ViewBag.Message = "Form submitted";


            return View();
        }


    }
}
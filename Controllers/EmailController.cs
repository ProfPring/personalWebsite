﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmailController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public string sendemail(string FromName, string FromEmail, string Message)
        {
            
            Debug.WriteLine("this run");
            try
            {
                if (ModelState.IsValid)
                {
                    var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                    var message = new MailMessage();
                    message.To.Add(new MailAddress("email@live.co.uk"));  // where the message is going 
                    message.From = new MailAddress("email@gmail.com");  // being sent from
                    message.Subject = "from website";
                    message.Body = string.Format(body, FromName, FromEmail, Message);
                    message.IsBodyHtml = true;

                    using (var smtp = new SmtpClient())
                    {
                        var credential = new NetworkCredential
                        {
                            UserName = "email@gmail.com",
                            Password = "password"
                        };
                        smtp.EnableSsl = true;
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = credential;
                        smtp.Host = "smtp.gmail.com";
                        smtp.Timeout = 10000;
                        smtp.Port = 587;
                        smtp.Send(message);
                        RedirectToAction("Index");
                        return "<h2>thank you, Your message has been sent!</h2>";

                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return e.ToString();

            }
            return "";
        }
    }
}
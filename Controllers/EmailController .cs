using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web.UI.WebControls;
using System.Web;
using System.ComponentModel;

namespace main_for_API.Controllers
{
    public class EmailController
    {
        static bool mailSent = false;

        public static void SendMialCallback(object sender, AsyncCompletedEventArgs e)
        {
            string token = (string)e.UserState;

            if (e.Cancelled)
            {
                Console.WriteLine("[{0}] sending cancled.", token);
            }
            else
            {
                Console.WriteLine("sending mail", token);
            }
            if (e.Error != null)
            {
                Console.WriteLine("[{0}] {1}", token, e.Error.ToString());
            }
            else
            {
                Console.WriteLine("Message sent!");
            }

            mailSent = true;
        }


        public static void  sendemail()
        {
            // Command-line argument must be the SMTP host.
            SmtpClient client = new SmtpClient();
            MailMessage message = new MailMessage();
            client.Port = 25;

            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;

            client.Host = "smtp.gmail.com";
            message.Body = "This is a test email message sent by an application. ";
            
          
         

            Console.WriteLine("sending Message...press c to cancel. press any other button to exit");

            string input = Console.ReadLine(); 
            // then cancel the pending operation.
            if (input.StartsWith("c") && mailSent == false)
            {
                Console.WriteLine("canceling send");
                client.SendAsyncCancel();
            }
            // Clean up.
  
            Console.WriteLine("Goodbye.");
        }
         
    }
}
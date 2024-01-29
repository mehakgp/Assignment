using System;

using System.Net;
using System.Net.Mail;

namespace Testing_email
{
    class Program
    {
        public static void Main(string[] args)
        {
            MailAddress to = new MailAddress("mehak.g@mindfiresolutions.com");
            MailAddress from = new MailAddress("mehakgupta2253@gmail.com");

            MailMessage email = new MailMessage(from, to);
            email.Subject = "Testing email ";
            email.Body = "Hello!!!!!";

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "sandbox.smtp.mailtrap.io";
            smtp.Port = 2525;
            smtp.Credentials = new NetworkCredential("60c55e7b55c24b", "b7e97f832d6546");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;

            try
            {
                smtp.Send(email);
            }
            catch (SmtpException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
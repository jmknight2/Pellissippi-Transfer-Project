using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
/// <summary>
/// This is where emails actually get sent. It requires a list of people to have the email sent.
/// </summary>
namespace cliEmail
{
    class email
    {
        public static void sendMail(ref emailConfiguration config, ref message htmlMessage,string[] attachments)
        {
            MailMessage newMessage = new MailMessage();
            newMessage.From = config.from;
            foreach(MailAddress element in config.to)
            {
                newMessage.To.Add(element);
            }

            newMessage.Subject = htmlMessage.subject;
            AlternateView alternate = AlternateView.CreateAlternateViewFromString(htmlMessage.body, null, MediaTypeNames.Text.Html);
            newMessage.AlternateViews.Add(alternate);

            SmtpClient client = new SmtpClient(config.smtpServer);
            client.Port = config.smtpPort;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(config.sendingEmail, config.sendingPass);
            client.EnableSsl = true;

            //adding attachments:
            if(attachments.Length > 0)
            {
                foreach(string attachment in attachments)
                {
                    //Console.WriteLine(attachment);
                    newMessage.Attachments.Add(new Attachment(attachment, MediaTypeNames.Application.Octet));
                }
            }

            try
            {
                client.Send(newMessage);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
    class emailConfiguration
    {
        public List<MailAddress> to;
        public MailAddress from;

        public string smtpServer;
        public int smtpPort;
        public string sendingEmail;
        public string sendingPass;

        public emailConfiguration(List<string> input)
        {
            //hard coding the required values to send an email off:
            to = new List<MailAddress>();
            from = new MailAddress(input[3], input[2]);
            sendingEmail = input[4];
            sendingPass = input[5];
            smtpServer = input[6];
            smtpPort = Convert.ToInt32(input[7]);

            //Grabbing the recipients:
            string[] curr;
            for (int i = 8; i < input.Count; i++)
            {
                curr = input[i].Split(',');
                to.Add(new MailAddress(curr[1], curr[0]));
            }
        }
    }
    class message
    {
        public string subject;
        public string body;
        public message(string subjectIn, string bodyIn)
        {
            subject = subjectIn;
            body = bodyIn;
        }
    }
}

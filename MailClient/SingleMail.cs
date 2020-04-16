using System.Net.Mail;

namespace MailClientFluentApi
{
    public class SingleMail
    {
        public string Sender { get; private set; }
        public string Receiver { get; private set; }
        public string Subject { get; private set; }
        public string Body { get; private set; }

        public SingleMail(string sender, string receiver, string subject, string body)
        {
            Sender = sender;
            Receiver = receiver;
            Subject = subject;
            Body = body;
        }

        public MailMessage GetMessage()
        {
            var msg = new MailMessage(new MailAddress(Sender), new MailAddress(Receiver));
            msg.Body = Body;
            msg.IsBodyHtml = true;
            msg.Subject = Subject;

            return msg;
        }
    }
}
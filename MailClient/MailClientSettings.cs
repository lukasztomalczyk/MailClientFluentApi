using System;

namespace MailClientFluentApi
{
    public class MailClientSettings
    {
        public string SmtpPort { get; private set; }
        public string SmtpServer { get; private set; }
        public string SmtpSender { get; private set; }


        public MailClientSettings SetPort(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException("Provide port number for mail Client!");
            SmtpPort = value;
            return this;
        }

        public MailClientSettings SetServer(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException("Provide server address for mail Client!");
            SmtpServer= value;
            return this;
        }

        public MailClientSettings SetSender(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException("Provide server address for mail Client!");
            SmtpSender= value;
            return this;
        }
    }
}
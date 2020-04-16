using Microsoft.Extensions.Logging;

namespace MailClientFluentApi
{
    public interface IMailClient : ISetLogger, IPutMailingList
    {
        
    }

    public interface ISetLogger
    {
        IPutMailingList SetLogger(ILogger logger);
    }

    public interface IPutMailingList
    {
        IMailClient PutMailToMailingList(string receiver, string body, string subject);
        void SendEmailToAllRecipients();
    }
}
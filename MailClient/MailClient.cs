using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace MailClientFluentApi
{
    public class MailClient : IMailClient
    {
        private ILogger _logger;
        private SmtpClient _client;
        private MailClientSettings _clientSettings = new MailClientSettings();

        private List<MailMessage> _receiverList = new List<MailMessage>();

        public MailClient(Action<MailClientSettings> action)
        {
            action(_clientSettings);
            _client.DeliveryMethod = SmtpDeliveryMethod.Network;
        }

        public IPutMailingList SetLogger(ILogger logger)
        {
            _logger = logger;
            return this;
        }

        public IMailClient PutMailToMailingList(string receiver, string body, string subject)
        {
            if (String.IsNullOrEmpty(receiver) | String.IsNullOrEmpty(body) | String.IsNullOrEmpty(subject))
            {
                _logger.LogError(@"Provide required data for email message! Receiver: {receiver}, Subject: {subject}, Body: {body}");
                throw new ArgumentNullException("Provide required data for email message!");
            }

            _receiverList.Add(new SingleMail(_clientSettings.SmtpSender, receiver, subject, body).GetMessage());

            return this;
        }

        public void SendEmailToAllRecipients()
        {
            if (_receiverList.Count == 0)
                throw new ArgumentException("You dont't have any mail to send!");

            foreach (var msg in _receiverList)
            {
                try
                {
                    var cts = new CancellationTokenSource();
                    _client.SendAsync(msg, cts.Token);
                }
                catch (Exception ex)
                {
                    _logger.LogError(@"Cannot send email!", ex);
                    throw new InvalidOperationException("Cannot send email!");
                }
            }
        }
    }
}
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MailClientFluentApi
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterMailClient(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddScoped<IMailClient>(x => new MailClient(options => {
                options.SetPort(configuration.GetValue<string>("MailClient:SMTPClientServer"));
                options.SetServer(configuration.GetValue<string>("MailClient:SMTPClientPort"));
                options.SetSender(configuration.GetValue<string>("MailClient:SMTPClientSender"));
            }));
        }
    }
}
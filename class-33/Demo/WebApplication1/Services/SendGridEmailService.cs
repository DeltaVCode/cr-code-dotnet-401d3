using System;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace WebApplication1.Services
{
    public class SendGridHttpEmailService : IEmailService
    {
        public IConfiguration configuration;

        public SendGridHttpEmailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public Task SendEmail(string email, string subject, string body)
        {
            var http = new HttpClient();
            var sendUrl = configuration["SendGrid:ApiSendUrl"] ?? throw new InvalidOperationException("Missing ApiSendUrl");

            // http.PostAsync(sendUrl, )
            throw new NotSupportedException("This is too hard");
        }
    }

    public class SendGridSmtpEmailService : IEmailService
    {
        public Task SendEmail(string email, string subject, string body)
        {
            var smtp = new SmtpClient();
            // ...
            return Task.CompletedTask;
        }
    }
}

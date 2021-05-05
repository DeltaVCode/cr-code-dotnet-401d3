using System;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace WebApplication1.Services
{
    public class SendGridEmailService : IEmailService
    {
        public IConfiguration configuration;

        public SendGridEmailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task SendEmail(string email, string subject, string body)
        {
            // var apiKey = Environment.GetEnvironmentVariable("NAME_OF_THE_ENVIRONMENT_VARIABLE_FOR_YOUR_SENDGRID_KEY");
            var apiKey = configuration["SendGrid:ApiKey"] ?? throw new InvalidOperationException("Missing ApiKey");

            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(configuration["SendGrid:FromEmail"]);
            // var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress(email);
            // var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = $"<strong>{body}</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, body, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Services
{
    public interface IEmailService
    {
        Task SendEmail(string email, string subject, string body);
    }

    public class NullEmailService : IEmailService
    {
        public Task SendEmail(string email, string subject, string body)
        {
            return Task.CompletedTask;
        }
    }

    public class LoggerEmailService : IEmailService
    {
        private readonly ILogger<LoggerEmailService> logger;

        public LoggerEmailService(ILogger<LoggerEmailService> logger)
        {
            this.logger = logger;
        }

        public Task SendEmail(string email, string subject, string body)
        {
            logger.LogInformation("Sending to {0} with subject '{2}'", email, subject);
            return Task.CompletedTask;
        }
    }
}

using System;
using System.Net.Mail;
using System.Threading.Tasks;
using CASample.Application.Common.Interfaces;
using CASample.Application.Common.Models;
using Microsoft.Extensions.Logging;

namespace CASample.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly ILogger<EmailService> _logger;

        public EmailService(ILogger<EmailService> logger)
        {
            _logger = logger;
        }

        public async Task SendAsync(EmailRequest request)
        {
            var emailClient = new SmtpClient("localhost");

            var message = new MailMessage
            {
                From = new MailAddress(request.FromMail),
                Subject = request.Subject,
                Body = request.Body
            };

            foreach (string to in request.ToMail)
            {
                message.To.Add(new MailAddress(to));
            }
 
            //TODO:EmailService if there was error, try at least three times. 
            try
            {
                await emailClient.SendMailAsync(message);
            }
            catch(Exception ex) 
            {
                _logger.LogError(ex, "CASample EmailService: Unhandled Exception for Request {@Request}", request);
            }

            _logger.LogWarning($"Sending email to {request.ToMail} from {request.FromMail} with subject {request.Subject}.");

        }
    }
}

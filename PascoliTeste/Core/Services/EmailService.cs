using Core.Model;
using Core.Services.Interfaces;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace Core.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;
        private readonly SmtpClient _smtpClient;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
            _smtpClient = new SmtpClient(_emailSettings.MailServer, _emailSettings.MailPort)
            {
                Credentials = new NetworkCredential(_emailSettings.Sender, _emailSettings.Password),
                EnableSsl = true
            };
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress(_emailSettings.Sender, _emailSettings.SenderName),
                Subject = subject,
                Body = message,
                IsBodyHtml = true
            };

            mailMessage.To.Add(email);

            await _smtpClient.SendMailAsync(mailMessage);
        }
    }
}


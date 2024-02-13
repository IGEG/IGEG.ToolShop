using IGEG.ToolShop.Application.Contracts.Email;
using IGEG.ToolShop.Application.Contracts.Email.Models;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace IGEG.ToolShop.Infrastructure.Email
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _settings;

        public EmailService(IOptions<EmailSettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task SendMessage(EmailMessage email)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(email.From, _settings.Name));
            emailMessage.To.Add(new MailboxAddress("", _settings.Name));
            emailMessage.Subject = email.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = email.Body
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_settings.Host, Convert.ToInt32(_settings.Port), false);
                await client.AuthenticateAsync(_settings.Name, _settings.Password);
                emailMessage.Subject = email.Subject;
                await client.DisconnectAsync(true);
            }
        }
    }
}

using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using Services.Abstractions;
using Services.Utilities;
using Shared;

namespace Services
{
    public class EmailService : IEmailService
    {
        private readonly IOptions<EmailSettings> _options;

        public EmailService(IOptions<EmailSettings> options)
        {
            _options = options;
        }
        public async Task SendEmailAsync(Email email)
        {
            var message = new MimeMessage()
            {
                Sender = MailboxAddress.Parse(_options.Value.SenderEmail),
                Subject = email.Subject,
            };
            message.From.Add(new MailboxAddress(_options.Value.SenderEmail, _options.Value.DisplayName));
            message.To.Add(MailboxAddress.Parse(email.To));

            var builder = new BodyBuilder();
            builder.TextBody = email.Body;

            message.Body = builder.ToMessageBody();


            using var client = new SmtpClient();
            await client.ConnectAsync(_options.Value.Host, _options.Value.Port, MailKit.Security.SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(_options.Value.SenderEmail, _options.Value.Password);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
    }
}

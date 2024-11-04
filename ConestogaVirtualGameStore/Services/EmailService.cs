using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace ConestogaVirtualGameStore.Services
{
    public class EmailService
    {

        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string recipientEmail,  string subject, string message)
        {
            ValidateSmtpSettings();

            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(_configuration["SmtpSettings:SenderName"], _configuration["SmtpSettings:SenderEmail"]));
            email.To.Add(MailboxAddress.Parse(recipientEmail));
            email.Subject = subject;

            var builder = new BodyBuilder { HtmlBody = message };
            email.Body = builder.ToMessageBody();

            using var smtpClient = new SmtpClient();

            try
            {
                await smtpClient.ConnectAsync(
                    _configuration["SmtpSettings:Server"],
                    int.Parse(_configuration["SmtpSettings:Port"]),
                    MailKit.Security.SecureSocketOptions.StartTls
                );

                smtpClient.AuthenticationMechanisms.Remove("XOAUTH2");
                smtpClient.Timeout = 10000;
                await smtpClient.AuthenticateAsync(_configuration["SmtpSettings:Username"], _configuration["SmtpSettings:Password"]);
                await smtpClient.SendAsync(email);
               
            }
            catch (SmtpCommandException ex)
            {
                Console.WriteLine($"SMTP Command Exception: {ex.StatusCode} - {ex.Message}");
            }
            catch (AuthenticationException ex)
            {
                Console.WriteLine($"Authentication failed: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                if (smtpClient.IsConnected)
                    await smtpClient.DisconnectAsync(true);
            }
        }

        private void ValidateSmtpSettings()
        {
            if (string.IsNullOrEmpty(_configuration["SmtpSettings:Server"]) ||
                string.IsNullOrEmpty(_configuration["SmtpSettings:Username"]) ||
                string.IsNullOrEmpty(_configuration["SmtpSettings:Password"]))
            {
                throw new InvalidOperationException("SMTP settings are missing required values.");
            }
        }
    }
}

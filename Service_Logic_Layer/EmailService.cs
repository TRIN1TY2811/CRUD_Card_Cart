using System;
using System.Net;
using System.Net.Mail;

namespace Service_Logic_Layer
{
    public class EmailService
    {
        private readonly string _host;
        private readonly int _port;
        private readonly string _username;
        private readonly string _password;
        private readonly string _fromEmail;
        private readonly string _recipientEmail;

        public EmailService(string host, int port, string username, string password, string fromEmail, string recipientEmail)
        {
            _host = host;
            _port = port;
            _username = username;
            _password = password;
            _fromEmail = fromEmail;
            _recipientEmail = recipientEmail;
        }

        public void SendNotification(string subject, string body)
        {
            if (string.IsNullOrWhiteSpace(_password) || _password == "YOUR_MAILTRAP_PASSWORD_HERE")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"[Mailtrap Notice]: Email '{subject}' was not sent because the Mailtrap password in appsettings.json is not yet configured.");
                Console.ResetColor();
                return;
            }

            try
            {
                using (var client = new SmtpClient(_host, _port))
                {
                    client.Credentials = new NetworkCredential(_username, _password);
                    client.EnableSsl = true;

                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress(_fromEmail, "CRUD System Notification"),
                        Subject = subject,
                        Body = body,
                        IsBodyHtml = false
                    };

                    mailMessage.To.Add(_recipientEmail);
                    client.Send(mailMessage);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"[Mailtrap Alert]: Email sent successfully - '{subject}'");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[Mailtrap Error]: Could not send email: {ex.Message}");
                Console.ResetColor();
            }
        }
    }
}

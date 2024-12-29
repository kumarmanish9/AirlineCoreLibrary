using AirlineCoreLibrary.Model;
using AirlineCoreLibrary.Service;
using AirlineCoreLibrary.Utility;
using System.Net;
using System.Net.Mail;

namespace AirlineCoreLibrary.ServiceDefinition
{
    internal class Notification : INotification
    {
        public async Task<bool?> SendNotification(PassengerCompenation? passenger)
        {
            if (passenger == null) return false;

            try
            {
                // Get email template
                string emailTemplate = EmailTemplate.GetEmailContent(passenger, out string subject);

                // Send an email to the passenger
                await SendEmail(passenger.Email, subject, emailTemplate);

                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Failed to send notification. Error: {ex.Message}");
                return false;
            }
        }

        private static Task SendEmail(string? toEmail, string? subject, string? body)
        {
            try
            {
                // Create a new MailMessage object
                MailMessage mail = new();
                mail.From = new MailAddress(CoreConstants.SenderEmail); // Sender's email address
                mail.To.Add(toEmail ?? CoreConstants.SenderEmail);      // Receiver's email address
                mail.Subject = subject;                // Email subject
                mail.Body = body;                      // Email body
                mail.IsBodyHtml = true;                // Set to true if body contains HTML

                // Configure the SMTP client
                SmtpClient smtp = new (CoreConstants.SenderHost, CoreConstants.SenderPort); // Gmail SMTP server and port
                smtp.Credentials = new NetworkCredential(CoreConstants.SenderEmail, CoreConstants.SenderPass); // Credentials for the sender's Gmail account
                smtp.EnableSsl = true;                                      // Enable SSL for secure connection

                // Send the email
                smtp.Send(mail);
                AppLogger.LogInfo($"Email sent successfully to [{toEmail}]!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send email. Error: {ex.Message}");
            }
            return Task.CompletedTask;
        }
    }
}

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
                string emailTemplate = GetEmailContent(passenger, out string subject);

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

        /// <summary>
        /// Get Email Content/Template
        /// </summary>
        /// <param name="passenger"></param>
        /// <param name="subject"></param>
        /// <returns></returns>
        private static string GetEmailContent(PassengerCompenation passenger, out string subject)
        {
            subject = $"FlyingTogether {passenger.Compensation} Compensation";
            string body = passenger.Compensation switch
            {
                nameof(CompensationType.Hotel) => $"Dear {passenger.FirstName} {passenger.LastName}," +
                                       $"\n\nYour flight has been {passenger.EventReason}. " +
                                       $"We apologize for the inconvenience and will provide you with compensation." +
                                       $"\n\nBest regards," +
                                       $"\nFlying Together",
                                       
                nameof(CompensationType.Meal) => $"Dear {passenger.FirstName} {passenger.LastName}," +
                                       $"\n\nYour flight has been {passenger.EventReason}. " +
                                       $"We apologize for the inconvenience and will provide you with compensation." +
                                       $"\n\nBest regards," +
                                       $"\nFlying Together",
                                       
                nameof(CompensationType.HotelAndMeal) => $"Dear {passenger.FirstName} {passenger.LastName}," +
                                       $"\n\nYour flight has been {passenger.EventReason}. " +
                                       $"We apologize for the inconvenience and will provide you with compensation." +
                                       $"\n\nBest regards," +
                                       $"\nFlying Together",

                nameof(CompensationType.Voucher) => $"Dear {passenger.FirstName} {passenger.LastName}," +
                                       $"\n\nYour flight has been {passenger.EventReason}. " +
                                       $"We apologize for the inconvenience and will provide you with compensation." +
                                       $"\n\nBest regards," +
                                       $"\nFlying Together",

                nameof(CompensationType.Miles) => $"Dear {passenger.FirstName} {passenger.LastName}," +
                                       $"\n\nYour flight has been {passenger.EventReason}. " +
                                       $"We apologize for the inconvenience and will provide you with compensation." +
                                       $"\n\nBest regards," +
                                       $"\nFlying Together",

                _ => $"Dear {passenger.FirstName} {passenger.LastName}," +
                                       $"\n\nYour flight has been {passenger.EventReason}. " +
                                       $"We apologize for the inconvenience and will provide you with compensation." +
                                       $"\n\nBest regards," +
                                       $"\nFlying Together",
            };
            return body;
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
                SmtpClient smtp = new (CoreConstants.SenderHost, 587); // Gmail SMTP server and port
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

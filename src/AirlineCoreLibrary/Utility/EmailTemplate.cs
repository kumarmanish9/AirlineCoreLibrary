using AirlineCoreLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineCoreLibrary.Utility
{
    internal class EmailTemplate
    {
        public static string GetEmailContent(PassengerCompenation passenger, out string subject)
        {
            subject = $"FlyingTogether {passenger.Compensation} Compensation";

            string emailBody = $@"
                <!DOCTYPE html>
                <html>
                <head>
                    <style>
                        body {{
                            font-family: Arial, sans-serif;
                            line-height: 1.6;
                        }}
                        .email-container {{
                            padding: 20px;
                            border: 1px solid #ccc;
                            border-radius: 10px;
                            max-width: 600px;
                            margin: 20px auto;
                            background-color: #f9f9f9;
                        }}
                        .footer {{
                            margin-top: 20px;
                            font-size: 14px;
                            color: #555;
                        }}
                    </style>
                </head>
                <body>
                    <div class='email-container'>
                        <p>Dear {passenger.FirstName} {passenger.LastName},</p>
                        <p>
                            Your flight has been <strong>{passenger.EventReason}</strong>.
                            <br/>We apologize for the inconvenience and will provide you with compensation.
                        </p>
                        <p class='footer'>Best regards,<br>Flying Together</p>
                    </div>
                </body>
                </html>";

                return emailBody;
            }
        }
    }

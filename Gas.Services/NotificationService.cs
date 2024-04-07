using Gas.Utils.Settings;
using System.Net;
using System.Net.Mail;

namespace Gas.Services
{
    public static class NotificationService
    {
        public static bool SendMailService(string body, string recipientEmail)

        {
            // Sender's Gmail address
            string senderEmail = ServiceSettings.GetWorkerServiceSettings().Email.SenderEmail;
            // Sender's Gmail password
            string senderPassword = ServiceSettings.GetWorkerServiceSettings().Email.SenderPassword;

            // Create a new instance of the SmtpClient class
            SmtpClient client = new SmtpClient(ServiceSettings.GetWorkerServiceSettings().Email.Host);
            // Set the SMTP port for Gmail
            client.Port = ServiceSettings.GetWorkerServiceSettings().Email.Port;

            // Set the credentials (sender's Gmail address and password)
            client.Credentials = new NetworkCredential(senderEmail, senderPassword);

            // Enable SSL
            client.EnableSsl = true;

            client.UseDefaultCredentials = false;

            // Create a MailMessage object
            MailMessage mail = new();
            mail.From = new(senderEmail);
            mail.To.Add(recipientEmail);
            mail.Subject = ServiceSettings.GetWorkerServiceSettings().Email.Subject;
            mail.Body = body;
            mail.IsBodyHtml = true; // Set to true if your email content is in HTML

            try
            {
                // Send the email
                client.Send(mail);
               return true;
            }
            catch (Exception ex)
            {
                Logger.Logger.Error($"Error sending email: {ex.Message}");
                return false;
            }
       }

        public static bool SendMailServiceWithAttachment(string body, string recipientEmail, byte[] dataToExport,string attachmentName)

        {
            // Sender's Gmail address
            string senderEmail = ServiceSettings.GetWorkerServiceSettings().Email.SenderEmail;
            // Sender's Gmail password
            string senderPassword = ServiceSettings.GetWorkerServiceSettings().Email.SenderPassword;

            // Create a new instance of the SmtpClient class
            SmtpClient client = new SmtpClient(ServiceSettings.GetWorkerServiceSettings().Email.Host);
            // Set the SMTP port for Gmail
            client.Port = ServiceSettings.GetWorkerServiceSettings().Email.Port;

            // Set the credentials (sender's Gmail address and password)
            client.Credentials = new NetworkCredential(senderEmail, senderPassword);

            // Enable SSL
            client.EnableSsl = true;

            client.UseDefaultCredentials = false;

            // Create a MailMessage object
            MailMessage mail = new();

            // Attach the PDF stream
            Attachment attachment = new Attachment(new MemoryStream(dataToExport), attachmentName);
            mail.Attachments.Add(attachment);

            mail.From = new(senderEmail);
            mail.To.Add(recipientEmail);
            mail.Subject = ServiceSettings.GetWorkerServiceSettings().Email.Subject;
            mail.Body = body;
            mail.IsBodyHtml = true; // Set to true if your email content is in HTML

            try
            {
                // Send the email
                client.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Logger.Error($"Error sending email: {ex.Message}");
                return false;
            }
        }

    }

}

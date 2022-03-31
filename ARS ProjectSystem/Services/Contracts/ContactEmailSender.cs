namespace ARS_ProjectSystem.Services.Contracts
{
    using ARS_ProjectSystem.EmailSender;
    using ARS_ProjectSystem.Models.Home;
    using ARS_ProjectSystem.Services.Projects;
    using SendGrid;
    using SendGrid.Helpers.Mail;
    using System.Linq;
    using System.Text;

    using static WebConstants;
    public class ContactEmailSender : IContactEmailSender
    {
        private readonly IProjectService projects;
        public ContactEmailSender(IProjectService projects)
        {
            this.projects = projects;
        }
        public void SendEmail(ContactForm emailData, string apiKey)
        {
            var client = new SendGridClient(apiKey);

            var from = new EmailAddress(SentToEmail, "Contact Form");
            var subject = $"Sending from Contact Page";
            var to = new EmailAddress(SentToEmail);
            var html = new StringBuilder();
            html.AppendLine($"<h1>{emailData.Subject}<h1>");
            html.AppendLine($"<h3>{emailData.Name} with email {emailData.Email} whants to send you a message from contact page:<h3>");
            html.AppendLine($"<h3>{emailData.Message}<h3>");
            var htmlContent = html.ToString();
            var plainTextContent = $"<h1>{emailData.Name} sends you a Message:<h1>";

            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            client.SendEmailAsync(msg);
        }

        public void SendToEmail(int id, string apiKey)
        {
            var client = new SendGridClient(apiKey);

            var project = this.projects.AllProjects().FirstOrDefault(p => p.Id == id);

            var from = new EmailAddress(SentToEmail);
            var subject = $"Sending ProjectInformation {project.Name}";
            var to = new EmailAddress(project.CustomerRegistrationNumber);
            var html = new StringBuilder();
            html.AppendLine($"<h1>{project.Name}<h1>");
            html.AppendLine($"<h3>{project.ProjectPhoto}<h3>");

            var plainTextContent = $"<h1>{project.Name}<h1>";
            var htmlContent = html.ToString();
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            client.SendEmailAsync(msg);
        }
    }
}

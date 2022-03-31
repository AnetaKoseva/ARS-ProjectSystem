namespace ARS_ProjectSystem.EmailSender
{
    using ARS_ProjectSystem.Models.Home;
    using SendGrid.Helpers.Mail;

    public interface IContactEmailSender
    {
        void SendEmail(ContactForm emailData,string apiKey);
        void SendToEmail(int id, string apiKey);
    }
}

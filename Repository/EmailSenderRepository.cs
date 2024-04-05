using System.Net.Mail;
using System.Net;
using ClientApp.Data;
using ClientApp.Dto;

namespace ClientApp.Repository
{
    public class EmailSenderRepository : Interface.IEmailSender
    {
        private readonly DataContext _context;

        public EmailSenderRepository(DataContext context)
        {
            _context = context;
        }
        public void SendEmail(EmailDto request)
        {
            string mailfrom = "amgadmu935@gmail.com";
            var pw = "znewzyvclxzfzaxf";
            List<string> clientEmails = GetClientEmailsFromDatabase();

            foreach (string email in clientEmails)
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(mailfrom);
                mail.To.Add(email);
                mail.Subject = request.Subject;
                mail.Body = request.Body;

                var smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(mailfrom, pw);
                smtpClient.EnableSsl = true;
                smtpClient.Send(mail);
            }
        }



        private List<string> GetClientEmailsFromDatabase()
        {
            List<string> clientEmails = _context.Clients.Select(c => c.Email).ToList();

            return clientEmails;
        }

    }
}


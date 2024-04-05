using ClientApp.Dto;

namespace ClientApp.Interface
{
    public interface IEmailSender
    {
        void SendEmail(EmailDto request);
    }
}

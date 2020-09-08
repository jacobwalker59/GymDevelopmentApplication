using System.Threading.Tasks;

namespace API.EmailFolder.EmailInterface
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
        Task SendEmailAsync(Message message);
    }
}
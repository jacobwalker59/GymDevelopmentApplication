using API.EmailFolder.EmailInterface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EmailController: BaseAPIController
    {
        public IEmailSender _emailSender { get; }
        public EmailController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpGet]
        public void SendMessage(){
         var message = new EmailFolder.Message(new string[]
         { "aidanw549@gmail.com" }, "Lamby has infiltrated the internet!", "He says his ambition is to steal everyone's left shoe!!.");
        _emailSender.SendEmail(message);
        }
    }
}
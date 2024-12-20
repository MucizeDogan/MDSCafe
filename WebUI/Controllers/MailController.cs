using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using WebUI.Dtos.MailDto;

namespace WebUI.Controllers {
    public class MailController : Controller {
        [HttpGet]
        public IActionResult Index() {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CreateMailDto createMailDto) {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddress = new MailboxAddress("MDS Cafe", "tourmds@gmail.com"); // Kimden
            mimeMessage.From.Add(mailboxAddress);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", createMailDto.ReceiverMail); // Kime
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder(); 
            bodyBuilder.TextBody = createMailDto.Message; // İçerik
            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Subject = createMailDto.Subject;// Konu

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("tourmds@gmail.com", "fdes varm reup suyk");

            client.Send(mimeMessage);
            client.Disconnect(true);

            return RedirectToAction("Index","Booking");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using MailKit.Net.Smtp;

namespace SendEmail.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SendMailController : ControllerBase
    {
        public SendMailController()
        {
        }

        [HttpGet]
        public async Task<IActionResult> EnviarEmail()
        {
            try
            {
                var message = new EmailMessage()
                {
                    From = "email@gmail.com",
                    To = "email@gmail.com",
                    MessageText = "Cuerpito",
                    Subject = "Test C# EnviarEmail API"
                };
                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 465, true);
                    client.Authenticate(message.From, "password");
                    client.Send(message.GetMessage());
                    client.Disconnect(true);
                }
                Console.WriteLine("Email enviado");
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }
    }
}
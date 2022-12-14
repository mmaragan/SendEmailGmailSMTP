using MimeKit;

namespace SendEmail
{
    public class EmailMessage
    {
        public string From { get; set; }
        public string To { get; set; }
        public string MessageText { get; set; }
        public string Subject { get; set; }
        public MimeMessage GetMessage()
        {
            var body = MessageText;
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("test", From));
            message.To.Add(new MailboxAddress("test", To));
            message.Subject = Subject;
            message.Body = new TextPart("plain") { Text = body };
            return message;
        }
    }
}

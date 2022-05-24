using MimeKit;
using System.Collections.Generic;
using System.Linq;

namespace Core.Services.Notification.Email.Models
{
    public class Message
    {
        public Message(List<string> to, string subject, string body)
        {
            To = new List<MailboxAddress>();
            To.AddRange(to.Select(x => new MailboxAddress(x)));
            Subject = subject;
            Body = body;
        }

        public string Subject { get; set; }

        public string Body { get; set; }

        public List<MailboxAddress> To { get; set; }
    }
}

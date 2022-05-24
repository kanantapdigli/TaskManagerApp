using Core.Services.Notification.Email.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Notification.Email.Abstraction
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Message message);
    }
}

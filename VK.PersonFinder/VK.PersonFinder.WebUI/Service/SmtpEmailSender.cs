using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace VK.PersonFinder.WebUI.Service
{
    public class SmtpEmailSender : IEmailSender
    {
        IOptions<SmtpOptions> _options;

        public SmtpEmailSender(IOptions<SmtpOptions> options)
        {
            _options = options;
        }

        public async Task SendEmailAsync(string fromAddress, string toAddress, string subject, string message)
        {
            MailMessage mailMessage = new MailMessage(fromAddress, toAddress, subject, message);
            using (SmtpClient client = new SmtpClient(_options.Value.Host, _options.Value.Port))
            {
                client.Credentials = new NetworkCredential(_options.Value.UserName, _options.Value.Password);
                await client.SendMailAsync(mailMessage);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VK.PersonFinder.WebUI.Service
{
    public class SmtpOptions
    {
        public string Host { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public int Port { get; set; }
    }
}

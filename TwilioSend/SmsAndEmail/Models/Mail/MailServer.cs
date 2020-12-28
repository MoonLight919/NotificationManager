using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmsAndEmail.Models
{
    public class MailServer
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public bool UseSsl { get; set; }
    }
}

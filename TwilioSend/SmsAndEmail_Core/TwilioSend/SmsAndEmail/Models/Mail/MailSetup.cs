using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmsAndEmail.Models
{
    public class MailSetup
    {
        public MailServer MailServer { get; set; }

        public MailUser MailUser { get; set; }
    }
}

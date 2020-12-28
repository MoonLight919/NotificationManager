using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmsAndEmail.Models
{
    public class SmsServer
    {
        public string AccountSid { get; set; }
        public string AuthToken { get; set; }
        public string PhoneNumber { get; set; }
        
    }
}

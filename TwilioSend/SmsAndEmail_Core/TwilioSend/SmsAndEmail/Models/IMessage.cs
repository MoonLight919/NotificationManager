using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmsAndEmail.Models
{
    public interface IMessage
    {
        IList<string> SendTo { get; set; }
        string MessageText { get; set; }
        bool Send();
    }
}

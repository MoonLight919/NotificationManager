using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmsAndEmail.Models
{
    public interface IEmailMessage : IMessage
    {
        IList<string> CCTo { get; set; } // копии
        IList<string> BCCTo { get; set; } // скрытые копии
        IList<string> AttachementFilePaths { get; set; } // приатаченные файлы
        string Subject { get; set; } // тема письма
    }
}

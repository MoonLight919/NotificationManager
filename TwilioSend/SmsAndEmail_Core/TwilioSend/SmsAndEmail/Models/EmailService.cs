using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmsAndEmail.Models
{
    public class EmailService : IEmailMessage
    {
        private readonly IOptions<MailSetup> config;

        private MimeMessage emailMessage;
        MailSetup mailSetup;
        public IList<string> SendTo { get; set; }
        public string MessageText { get; set; }
        //***********************************************************
        public IList<string> CCTo { get; set; }
        public IList<string> BCCTo { get; set; }
        public IList<string> AttachementFilePaths { get; set; }
        //***********************************************************
        public string Subject { get; set; }
        public EmailService(IOptions<MailSetup> configuration)
        {
            config = configuration;
            mailSetup = config.Value;
        }
       
        public bool Send()
        {
            emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress(mailSetup.MailUser.Name, mailSetup.MailUser.Name));
            //emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = MessageText
            };
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(mailSetup.MailServer.Host, mailSetup.MailServer.Port, mailSetup.MailServer.UseSsl);
                    client.Authenticate(mailSetup.MailUser.Name, mailSetup.MailUser.Password);
                    foreach (var email in SendTo)
                    {
                        emailMessage.To.Add(new MailboxAddress("", email));
                        client.Send(emailMessage);
                    }
                  
                    client.Disconnect(true);
                    return true;
                }
                catch (Exception exc)
                {
                    string err = exc.StackTrace;
                    throw new Exception("Error send EMail message");
                }
            }
        }
    }
}

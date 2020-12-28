using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace SmsAndEmail.Models
{
    public class SMSService : IMessage
    {
        private readonly IOptions<SmsSetup> config;
        public IList<string> SendTo  { get ; set; }
        public string MessageText { get; set; }
        SmsSetup smsSetup;
        public SMSService(IOptions<SmsSetup> configuration)
        {
            config = configuration;
            smsSetup = config.Value;
        }
        public bool Send()
        {
            try
            {
                TwilioClient.Init(smsSetup.SmsServer.AccountSid, smsSetup.SmsServer.AuthToken);
                foreach (var phone in SendTo)
                {
                    var message = MessageResource.Create(
                        body: "Test work with Twilio.",
                        from: new Twilio.Types.PhoneNumber(smsSetup.SmsServer.PhoneNumber),
                        to: new Twilio.Types.PhoneNumber(phone)
                        );
                }
                return true;
            }
            catch (Exception exc)
            {
                string err = exc.StackTrace;
                throw new Exception("Error send Sms message");
            }
        }
    }
}

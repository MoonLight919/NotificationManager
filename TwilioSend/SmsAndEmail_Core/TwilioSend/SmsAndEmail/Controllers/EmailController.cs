using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SmsAndEmail.Models;

namespace SmsAndEmail.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class EmailController : Controller
    {
        IEmailMessage emailService;
        public EmailController(IEmailMessage emailService)
        {
            this.emailService = emailService;
        }
        //[HttpPost]
        //public void Post()
        //{
        //    emailService.Subject = "Test Mail Kit Subject";
        //    emailService.MessageText = "Test Mail Kit MessageText";
        //    emailService.SendTo = new string[]
        //        { "mail.to.vasilenko@gmail.com", "ivasilenko@ukr.net" };
        //    emailService.Send();
        //}
        [HttpPost]
        public IActionResult Post([FromBody]Params obj)
        {
            //dynamic obj = data;
            //MessageBox.Show()

            emailService.Subject = obj.Subject;
            emailService.MessageText = obj.MessageText;
            emailService.SendTo = obj.SendTo;
            emailService.Send();
            return Ok();
        }
        [HttpGet]
        public string Get()
        {
            return "Hello world";
        }
    }
    public class Params
    {
        public string Subject { get; set; }
        public string MessageText { get; set; }
        public string[] SendTo { get; set; }

        //public Params(string Subject, string MessageText, string[] SendTo)
        //{
        //    this.Subject = Subject;
        //    this.SendTo = SendTo;
        //    this.MessageText = MessageText;
        //}
    }
}
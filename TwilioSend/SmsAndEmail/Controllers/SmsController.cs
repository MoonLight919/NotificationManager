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
    public class SmsController : Controller
    {
        IMessage smsService;
        public SmsController(IMessage message)
        {
            this.smsService = message;
        }

        [HttpPost]
        public IActionResult Post(Params obj)
        {
            smsService.MessageText = obj.MessageText;
            smsService.SendTo = obj.SendTo;
            smsService.Send();
            return Ok();
        }
        [HttpGet]
        public string Get()
        {
            return "Hello world";
        }
    }
}
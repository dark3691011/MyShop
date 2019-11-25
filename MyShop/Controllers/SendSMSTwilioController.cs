using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace MyShop.Controllers
{
    public class SendSMSTwilioController : Controller
    {
        public IActionResult Index()
        {
            // Find your Account Sid and Token at twilio.com/console
            // DANGER! This is insecure. See http://twil.io/secure
            const string accountSid = "ACf5dbb7cda8e1717451df1d91ed110064";
            const string authToken = "eda24973a6402c3dcea8d465741aaae5";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "Hello Im Hai",
                from: new Twilio.Types.PhoneNumber("+14844986307"),
                to: new Twilio.Types.PhoneNumber("+84329791369")
            );

            return View();
        }
    }
}
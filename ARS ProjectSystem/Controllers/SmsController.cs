namespace ARS_ProjectSystem.Controllers
{
    
    using Twilio;
    using Twilio.Rest.Api.V2010.Account;
    using Twilio.Types;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using ARS_ProjectSystem.Controllers.Sms;

    public class SmsController : Controller
    {
        public SmsController(IOptions<SMSoptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }
        public SMSoptions Options { get; }
        public IActionResult Index()
        {
            string accountSid = Options.AccountSID; ;
            string authToken = Options.AuthTOKEN;

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "This is the ship that made the Kessel Run in fourteen parsecs?",
                from: new PhoneNumber(Options.SMSAccountFrom),
                to: new PhoneNumber("+359877778827")
            );

            return Content(message.Sid);
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace spend_smart
{
    internal class SendSms
    {
        public static void SendingSms(string toPhoneNumber, string message)
        {
            // Initialize Twilio client
            TwilioClient.Init("ACef1950731e010d2b9bbd2d797db070e4", "09b20baf73be27e124c5ce2f5544c29b");

            // Create and send SMS message
            var smsMessage = MessageResource.Create(
                body: message,
                from: new Twilio.Types.PhoneNumber("+12513136264"),
                to: new Twilio.Types.PhoneNumber(toPhoneNumber)
            );
        }
    }
}

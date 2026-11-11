using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.Business
{
    public class TwilioSettings
    {
        public string AccountSid { get; set; } = string.Empty;
        public string AuthToken { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }
}

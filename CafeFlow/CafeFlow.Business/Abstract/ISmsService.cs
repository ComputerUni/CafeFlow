using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.Business.Abstract
{
    public interface ISmsService
    {
        Task<bool> SendSmsAsync(string phoneNumber, string contentSid, Dictionary<string, string>? variables = null);
    }
}

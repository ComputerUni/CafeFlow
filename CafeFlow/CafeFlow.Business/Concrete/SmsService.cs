using CafeFlow.Business.Abstract;
using CafeFlow.Business.Settings;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Twilio;
using Twilio.Exceptions;
using Twilio.Rest.Api.V2010.Account;
using Twilio.TwiML.Messaging;
using Twilio.Types;

namespace CafeFlow.Business.Concrete
{
    public class SmsService : ISmsService
    {
        private readonly TwilioSettings _twilioSettings;

        public SmsService(IOptions<TwilioSettings> twilioSettings)
        {
            _twilioSettings = twilioSettings.Value;
            TwilioClient.Init(_twilioSettings.AccountSid, _twilioSettings.AuthToken);
        }

        public async Task<bool> SendSmsAsync(string phoneNumber, string contentSid, Dictionary<string, string>? variables = null)
        {
            try
            {
                var formattedNumber = FormatPhoneNumber(phoneNumber);
                if (string.IsNullOrEmpty(formattedNumber)) return false;

                var messageResource = await MessageResource.CreateAsync(
                    from: new PhoneNumber($"whatsapp:{_twilioSettings.PhoneNumber}"),
                    to: new PhoneNumber($"whatsapp:{formattedNumber}"),
                    contentSid: contentSid,
                    contentVariables: variables != null && variables.Count > 0 ? JsonSerializer.Serialize(variables) : null
                );

                return messageResource.Status != MessageResource.StatusEnum.Failed;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                var code = ex is ApiException apiEx ? $" (Kod: {apiEx.Code})" : "";
                Console.WriteLine($"[Twilio SMS Hatası]{code}: {ex.Message}");
                Console.ResetColor();
                return false;
            }
        }

        private string FormatPhoneNumber(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
                return string.Empty;
            }

            var cleaned = new string(phone.Where(char.IsDigit).ToArray());
            if (cleaned.StartsWith("0"))
            {
                cleaned = cleaned.Substring(1);
            }
            if (!cleaned.StartsWith("90"))
            {
                cleaned = "90" + cleaned;
            }

            return "+" + cleaned;
        }
    }
}
